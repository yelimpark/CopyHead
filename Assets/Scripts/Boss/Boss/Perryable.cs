using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perryable : MonoBehaviour
{
    public GameObject attacker;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Animator>().GetBool("IsPerrying"))
        {
            other.GetComponent<BossScenePlayerMove>().OnParraing();
            gameObject.SetActive(false);

            if (attacker != null)
            {
                attacker.gameObject.SetActive(false);
            }
        }
    }
}
