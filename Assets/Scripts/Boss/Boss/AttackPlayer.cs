using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public bool IsPerryable = false;
    public bool IsDestroyable = false;

    public Animator player;

    public bool HandlePerry(Collider2D other)
    {
        if (player.GetBool("IsPerrying"))
        {
            other.gameObject.SetActive(false);
            return true;
        }

        return false;
    }

    public virtual void HandleDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (IsPerryable && HandlePerry(other))
                return;

            BossSceneAttackablePlayer player =  other.GetComponent<BossSceneAttackablePlayer>();
            if (!player.OnHitted())
                return;

            if (IsDestroyable)
                HandleDestroy();
        }
    }

}
