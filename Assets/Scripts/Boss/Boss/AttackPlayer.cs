using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public bool IsPerryable = false;
    public bool IsDestroyable = false;

    public bool HandlePerry()
    {
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
            if (IsPerryable && HandlePerry())
                return;

            BossSceneAttackablePlayer player =  other.GetComponent<BossSceneAttackablePlayer>();
            player.OnHitted();

            if (IsDestroyable)
                HandleDestroy();
        }
    }

}
