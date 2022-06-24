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

    Animator animator;
    Rigidbody2D rb;

    public float jumpPower = 35f;
    public float moveSpeed = 10f;
    public float dashLength = 3f;
    public float dashTime = 0.3f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (animator.GetBool("Shift"))
            return;

        horizontalInput = Input.GetAxis("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        if (horizontalInput * transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * (-1), 1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Z) && !animator.GetBool("Z"))
        {
            jumpKeystate = KeyState.DOWN;
            //animator.SetBool("Z", true);
        }
        if (!Input.GetKey(KeyCode.Z) && jumpKeystate == KeyState.HOLD)
        {
            jumpKeystate = KeyState.UP;
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
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            iTween.MoveBy(gameObject, iTween.Hash(
                "x", dashLength * transform.localScale.x,
                "time", dashTime,
                "oncomplete", "OnDashEnd"
            ));
            dashInput = false;
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

        velocity += Vector2.right * horizontalInput * moveSpeed;

        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Z", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Z", true);
        }
    }

    public void OnDashEnd()
    {
        rb.gravityScale = 7;
        animator.SetBool("Shift", false);
    }
}
