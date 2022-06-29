using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSceneAttackablePlayer : MonoBehaviour
{
    private Animator animator;
    private BossScenePlayerMove playerMove;

    public int Life { get; private set; }

    public GameObject goast;

    private void Start()
    {
        GameManager.Instnace.player = gameObject;

        animator = GetComponent<Animator>();
        playerMove = GetComponent<BossScenePlayerMove>();

        Life = GameVal.Instnace.MaxLife;
    }

    public bool OnHitted()
    {
        if (animator.GetBool("Shift"))
            return false;

        --Life;

        if (Life <= 0)
        {
            Instantiate(goast, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            playerMove.enabled = false;
            animator.SetBool("Attacked", true);
        }

        return true;
    }

    public void OnAttackedEnd()
    {
        playerMove.enabled = true;
        animator.SetBool("Attacked", false);
    }
}