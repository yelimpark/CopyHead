using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerGoast : MonoBehaviour
{
    public float time = 3f;

    void Start()
    {
        iTween.MoveTo(gameObject, iTween.Hash(
                "y", 10,
                "time", time
        ));
    }
}
