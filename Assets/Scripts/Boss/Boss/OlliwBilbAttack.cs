using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlliwBilbAttack : AttackPlayer
{
    public float speed;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        IsDestroyable = true;
    }

    private void OnEnable()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
            "y", -10f,
            "speed", speed,
            "oncomplete", "Deactive"
        ));
    }

    public override void HandleDestroy(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Ground"))
        {
            animator.SetTrigger("destroy");
            iTween.Stop(gameObject);
        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
