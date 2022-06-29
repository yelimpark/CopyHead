using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBoss : Attackable
{
    public float SinkSpeed;
    protected Animator animator;
    public GameObject vfxController;

    public override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    public override void OnDie()
    {
        vfxController.SetActive(true);
        GetComponent<Boss>().enabled = false;
        animator.SetTrigger("Die");
        iTween.MoveTo(gameObject, iTween.Hash(
            "delay", 2f,
            "y", -30f,
            "speed", SinkSpeed,
            "oncomplete", "Deactive"
        ));
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }
}
