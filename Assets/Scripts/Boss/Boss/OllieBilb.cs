using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OllieBilb : Boss
{
    public enum State
    {
        INTRO,
        IDLE,
        ATTACK,
    }

    private State curState;

    public State CurState
    {
        get { return curState; }
        set
        {
            switch (value)
            {
                case State.IDLE:
                    for (int i = 0; i < tears.Length; i++)
                    {
                        tears[i].GetComponent<Animator>().SetTrigger("turnOff");
                    }
                    animator.SetBool("Attack", false);
                    break;

                case State.ATTACK:
                    for (int i = 0; i < tears.Length; i++)
                    {
                        tears[i].GetComponent<Animator>().Rebind();
                        tears[i].SetActive(true);
                    }
                    animator.SetBool("Attack", true);
                    break;

                default:
                    break;
            }

            curState = value;
        }
    }

    public float SpawnPosY = 4f;

    public int attackNumber = 10;
    private int attackCounter = 6;
    public float attackSpeed = 0.7f;
    private float attackSpeedtimer = 0f;

    public GameObject[] tears = new GameObject[2];

    protected override void Awake()
    {
        base.Awake();
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

            case State.ATTACK:
                OnAttack();
                break;

            default:
                break;
        }
    }

    private void OnAttack()
    {
        attackSpeedtimer += Time.deltaTime;

        if (attackSpeedtimer >= attackSpeed)
        {
            attackSpeedtimer = 0f;
            ++attackCounter;
            bulletIdx = (bulletIdx == Bullets.Count - 1) ? 0 : bulletIdx + 1;

            if (attackCounter == attackNumber)
            {
                attackCounter = 0;
                CurState = State.IDLE;
                return;
            }

            Attack();
        }
    }

    public void Attack()
    {
        Vector3 spawnPos = Vector3.zero;
        spawnPos.x = RandomTearPosition();
        spawnPos.y = SpawnPosY;
        Bullets[bulletIdx].transform.position = spawnPos;
        Bullets[bulletIdx].SetActive(true);
    }

    float RandomTearPosition()
    {
        int screenWidthHalf = (int)Camera.main.orthographicSize * Screen.width / Screen.height;
        float scaleHalf = transform.localScale.x * 0.5f;

        if (Random.Range(0,2) == 0)
        {
            return Random.Range(screenWidthHalf * (-1), scaleHalf * (-1));
        }
        return Random.Range(scaleHalf, screenWidthHalf);
    }

    private void OnIdle()
    {
        attackIntervalTimer += Time.deltaTime;

        if (attackIntervalTimer >= attackInterval)
        {
            attackIntervalTimer = 0f;
            CurState = State.ATTACK;
        }
    }

    private void OnDie()
    {
        for (int i = 0; i < tears.Length; i++)
        {
            tears[i].GetComponent<Animator>().SetTrigger("turnOff");
        }
    }
}
