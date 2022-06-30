using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chauncey : Boss
{
    public enum State
    {
        INTRO,
        ATTACK,
        BEAM
    }

    private State curState;

    public State CurState
    {
        get { return curState; }
        set
        {
            switch (value)
            {
                case State.ATTACK:
                    animator.SetBool("Beam", false);
                    break;

                case State.BEAM:
                    animator.SetBool("Beam", true);
                    break;

                default:
                    break;
            }

            curState = value;
        }
    }

    public Transform[] spawnPos = new Transform[2];

    public int attackNumber = 7;
    private int attackCounter = 0;
    public float attackSpeed = 1f;
    private float attackSpeedtimer = 0f;

    public Transform raySpawnPos;
    public List<GameObject> rays = new List<GameObject>();
    private int rayIdx = 0;
    public int beamNumber = 3;
    private int beamCounter = 0;
    public float beamSpeed = 3f;
    private float beamSpeedtimer = 0f;

    protected override void Awake()
    {
        //GameManager.Instnace.FirstPhaseBoss = gameObject;

        base.Awake();
        CurState = State.INTRO;
    }

    public override void OnIntroEnd()
    {
        CurState = State.ATTACK;
    }

    void Update()
    {
        switch (CurState)
        {
            case State.ATTACK:
                OnAttack();
                break;

            case State.BEAM:
                OnBeam();
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
                CurState = State.BEAM;
                return;
            }

            Bullets[bulletIdx].transform.position = spawnPos[bulletIdx % 2].position;
            Bullets[bulletIdx].SetActive(true);
        }
    }

    private void OnBeam()
    {
        beamSpeedtimer += Time.deltaTime;

        if (beamSpeedtimer >= beamSpeed)
        {
            beamSpeedtimer = 0f;
            ++beamCounter;
            rayIdx = (rayIdx == rays.Count - 1) ? 0 : rayIdx + 1;

            if (beamCounter == beamNumber)
            {
                beamCounter = 0;
                CurState = State.ATTACK;
                return;
            }

            rays[rayIdx].transform.position = raySpawnPos.position;
            rays[rayIdx].SetActive(true);
        }
    }
}
