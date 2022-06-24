using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWorldMapMove : MonoBehaviour
{
    public Transform speechBubble;

    public float speed = 1f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var v = Input.GetAxisRaw("Vertical");

        // move
        Vector3 dir = new Vector3(h, v, 0f);
        dir.Normalize();

        transform.position += dir * speed * Time.deltaTime;

        // animation
        animator.SetBool("Walk", h != 0 || v != 0);

        animator.SetInteger("Horizontal", Utils.GetIntAxis(h));
        animator.SetInteger("Vertical", Utils.GetIntAxis(v));

        float scaleX = transform.localScale.x;
        if (h * scaleX < 0)
        {
            transform.localScale = new Vector3(scaleX * (-1), 1, 1);
        }

        if (speechBubble.localScale.x * scaleX < 0)
        {
            speechBubble.localScale = new Vector3(scaleX, 1, 1);
        }
    }
}

