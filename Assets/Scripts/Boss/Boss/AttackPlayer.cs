using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public bool IsDestroyable = false;

    public virtual void HandleDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BossSceneAttackablePlayer player = other.GetComponent<BossSceneAttackablePlayer>();
            if (!player.OnHitted())
                return;

            if (IsDestroyable)
                HandleDestroy();
        }
    }

}
