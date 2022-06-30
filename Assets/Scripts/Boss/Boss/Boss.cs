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

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnEnable()
    {
        
    }

    public virtual void OnIntroEnd() { }

    void Update()
    {
        
    }
}
