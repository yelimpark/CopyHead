using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalSpudder : Boss
{
    public enum State
    {
        INTRO,
        IDLE,
        ATTACK,
        HOLD,
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
                    {
                        animator.Play("SalSpudder_Attack", -1, 0f);
                        //animator.speed *= attackSpeed[attackSpeedIdx];
                    }

                    else if (curState == State.IDLE)
                        animator.SetBool("Attack", true);
                    break;

                default:
                    break;
            }

            curState = value;
        }
    }

    public List<float> attackSpeed = new List<float>();
    private int attackSpeedIdx = -1;
    private float attackSpeedtimer = 0f;

    public Transform spawnPos;

    protected override void Awake()
    {
        base.Awake();
        GameManager.Instnace.FirstPhaseBoss = gameObject;
        CurState = State.INTRO;
    }

    public override void OnIntroEnd()
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
