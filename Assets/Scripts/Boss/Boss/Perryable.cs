using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perryable : MonoBehaviour
{
    public bool isDeactiveable = true;

    public GameObject attacker;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (other.GetComponent<Animator>().GetBool("IsPerrying"))
        {
            other.GetComponent<BossScenePlayerMove>().OnParraing();

            if (isDeactiveable)
                OnDeactivate();

            if (attacker != null)
            {
                attacker.gameObject.SetActive(false);
            }
        }
    }

    public virtual void OnDeactivate()
    {
        gameObject.SetActive(false);
    }
}
