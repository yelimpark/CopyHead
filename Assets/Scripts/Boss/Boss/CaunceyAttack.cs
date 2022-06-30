using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaunceyAttack : AttackPlayer
{
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;
    public Transform player;
    public int rotateSpeed;
    public float gravityScale = 0.3f;

    private bool IsDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        IsDestroyable = true;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        if (rb != null)
            rb.gravityScale = gravityScale;
        IsDead = false;
    }

    private void FixedUpdate()
    {
        if (IsDead && player == null)
            return;

        Vector3 dir = player.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, rotateSpeed * Time.deltaTime);
        transform.rotation = rotation;

        Vector2 velocity = rb.velocity;
        velocity.x = dir.x * speed;
        rb.velocity = velocity;
    }

    public override void HandleDestroy(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            animator.SetTrigger("destroy");
            IsDead = true;
            rb.gravityScale = 0;
        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
