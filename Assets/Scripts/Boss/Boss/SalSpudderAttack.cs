using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalSpudderAttack : AttackPlayer
{
    public float speed;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        IsDestroyable = true;
    }

    private void OnEnable()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "x", -10f,
            "speed", speed,
            "oncomplete", "Deactive"
        ));
    }

    public override void HandleDestroy()
    {
        animator.SetTrigger("destroy");
        iTween.Stop(gameObject);
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}