using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerMove : MonoBehaviour
{
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
    }
}
