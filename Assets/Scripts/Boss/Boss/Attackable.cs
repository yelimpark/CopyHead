using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    public int maxHealth;
    private int health;
    public float SinkSpeed;
    Animator animator;
    SimpleFlash simpleFlash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        simpleFlash = GetComponent<SimpleFlash>();
        health = maxHealth;
    }

    public void OnHitted(int damage)
    {
        health -= damage;
        simpleFlash.Flash();

        if (health <= 0)
        {
            GetComponent<SalSpudder>().enabled = false;
            animator.SetTrigger("Die");
            iTween.MoveTo(gameObject, iTween.Hash(
                "delay", 2f,
                "y", -30f,
                "speed", SinkSpeed,
                "oncomplete", "Deactive"
            ));
        }
    }

    public void Deactive()
    {
        gameObject.SetActive(false);
    }

}