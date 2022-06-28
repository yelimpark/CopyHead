using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackable : MonoBehaviour
{
    public int maxHealth;
    protected int health;
    protected SimpleFlash simpleFlash;

    public virtual void Start()
    {
        simpleFlash = GetComponent<SimpleFlash>();
        health = maxHealth;
    }

    public void OnHitted(int damage)
    {
        health -= damage;
        simpleFlash.Flash();

        if (health <= 0)
        {
            OnDie();
        }
    }

    public virtual void OnDie()
    {
    }
}