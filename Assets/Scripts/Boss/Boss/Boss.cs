using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    protected Animator animator;

    public List<GameObject> Bullets = new List<GameObject>();
    protected int bulletIdx = 0;

    public float attackInterval = 2f;
    protected float attackIntervalTimer = 0f;

    protected virtual void Start()
    {
        GameManager.Instnace.PhaseBoss.Add(this.gameObject);
        animator = GetComponent<Animator>();
    }

    public virtual void OnIntroEnd() { }

    void Update()
    {
        
    }
}
