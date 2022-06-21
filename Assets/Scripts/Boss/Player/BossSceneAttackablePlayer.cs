using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneAttackablePlayer : MonoBehaviour
{
    private bool invisible = false;

    private Animator animator;
    private BossScenePlayerMove playerMove;

    private int Life;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerMove = GetComponent<BossScenePlayerMove>();

        Life = GameVal.Instnace.MaxLife;
    }

    public void OnHitted()
    {
        if (invisible)
            return;

        --Life;
        
        if (Life <= 0)
        {
            animator.SetTrigger("Die");
        }
        else
        {
            animator.SetTrigger("Attacked");
        }
    }
}