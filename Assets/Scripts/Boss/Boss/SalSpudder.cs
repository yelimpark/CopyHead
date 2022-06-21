using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalSpudder : MonoBehaviour
{
    public enum State
    {
        INTRO,
        IDLE,
        ATTACK,
        HOLD,
        DEATH
    }

    private State curState;

    public State CurState
    {
        get { return curState; }
        set {
            switch (value)
            {
                case State.IDLE:
                    animator.SetBool("Attack", false);
                    break;

                case State.ATTACK:
                    if (curState == State.HOLD)
                        animator.Play("SalSpudder_Attack", -1 ,0f);

                    else if (curState == State.IDLE)
                        animator.SetBool("Attack", true);
                    break;
            }

            curState = value;
        }
    }

    private Animator animator;

    public List<float> attackSpeed = new List<float>();
    private int attackSpeedIdx = -1;
    private float attackSpeedtimer = 0f;

    public float attackInterval = 2f;
    private float attackIntervalTimer = 0f;

    public List<GameObject> Bullets = new List<GameObject>();
    private int bulletIdx = 0;

    public Transform spawnPos;

    void Start()
    {
        animator = GetComponent<Animator>();
        CurState = State.INTRO;
    }

    public void OnIntroEnd()
    {
        CurState = State.IDLE;
    }

    void Update()
    {

        switch (CurState)
        {
            case State.IDLE:
                OnIdle();
                break;

            case State.HOLD:
                OnHold();
                break;

            default:
                break;
        }
    }

    private void OnHold()
    {
        attackSpeedtimer += Time.deltaTime;

        if (attackSpeedtimer >= attackSpeed[attackSpeedIdx] / (Bullets.Count - 1))
        {
            attackSpeedtimer = 0f;
            ++bulletIdx;

            if (bulletIdx == Bullets.Count - 1)
            {
                bulletIdx = 0;
                CurState = State.IDLE;
                return;
            }

            CurState = State.ATTACK;
        }
    }

    public void PotatoAttack()
    {
        Bullets[bulletIdx].transform.position = spawnPos.position;
        Bullets[bulletIdx].SetActive(true);
        CurState = State.HOLD;
    }

    private void OnIdle()
    {
        attackIntervalTimer += Time.deltaTime;

        if (attackIntervalTimer >= attackInterval)
        {
            ++attackSpeedIdx;
            if (attackSpeedIdx == attackSpeed.Count - 1)
            {
                attackSpeedIdx = 0;
            }

            attackIntervalTimer = 0f;
            CurState = State.ATTACK;
        }
    } 
}
