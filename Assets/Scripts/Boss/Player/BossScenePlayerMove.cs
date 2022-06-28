using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerMove : MonoBehaviour
{
    enum KeyState
    {
        DOWN,
        HOLD,
        UP,
        NONE
    }

    KeyState jumpKeystate = KeyState.NONE;
    float horizontalInput = 0;
    bool dashInput = false;
    bool onPlatform = false;

    Animator animator;
    Rigidbody2D rb;
    BoxCollider2D trigerCollider;

    public float jumpPower = 27f;
    public float moveSpeed = 10f;
    public float dashPower = 20f;
    public float dashTime = 0.2f;
    public float perryPower = 20f;
    public float perryTime = 0.2f;

    public float gravitiyScale = 7f;

    public delegate void Del();

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        trigerCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (animator.GetBool("Shift"))
            return;

        horizontalInput = Input.GetAxis("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (horizontalInput * transform.localScale.x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !animator.GetBool("Z")
            && !(onPlatform && Input.GetKey(KeyCode.DownArrow)))
        {
            jumpKeystate = KeyState.DOWN;
        }
        if (!Input.GetKey(KeyCode.Z) && jumpKeystate == KeyState.HOLD)
        {
            jumpKeystate = KeyState.UP;
        }

        if (animator.GetBool("Z") && Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("IsPerrying", true);
            Debug.Log(true);
            Del turnOffPerry = delegate { animator.SetBool("IsPerrying", false); };
            StartCoroutine(CoAnimatorTimer(perryTime, turnOffPerry));
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dashInput = true;
            animator.SetBool("Shift", true);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("X", true);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetBool("X", false);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("C", true);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("C", false);
        }

        var currentAnimation = animator.GetCurrentAnimatorStateInfo(0);
        if (currentAnimation.IsName("cuphead_DuckIdle") || currentAnimation.IsName("cuphead_ShootDuck"))
        {
            animator.SetBool("Duckable", false);
        }
        else
        {
            animator.SetBool("Duckable", true);
        }

        animator.SetInteger("Horizontal", Utils.GetIntAxis(horizontalInput));
        animator.SetInteger("Vertical", Utils.GetIntAxis(v));
    }

    void FixedUpdate()
    {
        if (dashInput)
        {
            rb.velocity = Vector2.right * transform.localScale.x * dashPower;
            rb.gravityScale = 0;
            dashInput = false;
            StartCoroutine(CoAnimatorTimer(dashTime, OnDashEnd));
        }

        if (animator.GetBool("Shift"))
            return;

        Vector2 velocity = new Vector2(0, rb.velocity.y);

        if (jumpKeystate == KeyState.DOWN)
        {
            velocity.y = jumpPower;
            jumpKeystate = KeyState.HOLD;
        }
        if (jumpKeystate == KeyState.UP)
        {
            velocity.y *= 0.5f;
            jumpKeystate = KeyState.NONE;
        }

        if (animator.GetBool("C") || animator.GetInteger("Vertical") < 0)
        {
            rb.velocity = velocity;
            return;
        }

        velocity += horizontalInput * moveSpeed * Vector2.right;

        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        trigerCollider.enabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Z", true);
            //trigerCollider.enabled = false;

        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            animator.SetBool("Z", true);
            onPlatform = false;
            //trigerCollider.enabled = false;
        }
    }

    public void OnDashEnd()
    {
        rb.gravityScale = gravitiyScale;
        animator.SetBool("Shift", false);
    }

    public void OnParraing()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = perryPower;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Z", false);
            animator.SetBool("IsPerrying", false);
        }
        else if (collision.gameObject.CompareTag("Platform") && rb.velocity.y == 0)
        {
            animator.SetBool("Z", false);
            onPlatform = true;
            animator.SetBool("IsPerrying", false);
        }
        trigerCollider.enabled = false;
    }

    IEnumerator CoAnimatorTimer(float time, Del method)
    {
        yield return new WaitForSeconds(time);

        method();
        Debug.Log(false);
    }

}
