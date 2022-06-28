using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableObstacle : Attackable
{
    public GameObject vfx;

    public override void OnDie()
    {
        gameObject.SetActive(false);
        vfx.SetActive(true);
    }
}
