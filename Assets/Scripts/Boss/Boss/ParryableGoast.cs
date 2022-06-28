using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryableGoast : Perryable
{
    Animator animator;
    CircleCollider2D circleCollider;
    
    public GameObject vfx;

    private void Start()
    {
        animator = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    public override void OnDeactivate()
    {
        circleCollider.enabled = false;
        animator.SetTrigger("revive");
    }

    public void OnRivive()
    {
        vfx.transform.position = transform.position;
        vfx.SetActive(true);
        gameObject.SetActive(false);
    }
}
