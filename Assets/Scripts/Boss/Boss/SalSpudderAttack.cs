using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalSpudderAttack : AttackPlayer
{
    private Vector3 InitialPos;
    public float speed;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        IsDestroyable = true;
        InitialPos = transform.position;
    }

    private void OnEnable()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "position", InitialPos,
            "speed", speed
        ));
    }

    public override void HandleDestroy()
    {
        animator.SetTrigger("destroy");
    }

    public void OnDestroyAnimationEnd()
    {
        Destroy(gameObject);
    }
}