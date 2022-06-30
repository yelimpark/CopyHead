using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBoss : Attackable
{
    public float SinkSpeed;
    protected Animator animator;
    public GameObject vfxController;

    public GameObject NextPahseBoss;

    public float sinkPos = -5f;

    public override void Start()
    {
        animator = GetComponent<Animator>();
        base.Start();
    }

    public override void OnDie()
    {
        vfxController.transform.position = transform.position;
        vfxController.SetActive(true);
        GetComponent<Boss>().enabled = false;
        animator.SetTrigger("Die");
        iTween.MoveTo(gameObject, iTween.Hash(
            "delay", 2f,
            "y", sinkPos,
            "speed", SinkSpeed,
            "oncomplete", "Deactive"
        ));
    }

    public void Deactive()
    {
        if (NextPahseBoss == null)
        {
            GameManager.Instnace.CurState = GameState.OUTRO;
            return;
        }
        ++GameManager.Instnace.curPhase;
        NextPahseBoss.SetActive(true);
        gameObject.SetActive(false);
    }

    //public void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        health -= 20;
    //    }

    //    if (health <= 0)
    //    {
    //        OnDie();
    //    }
    //}
}
