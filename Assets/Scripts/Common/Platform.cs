using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    PlatformEffector2D effector;
    private void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                effector.rotationalOffset = 180f;
            }
            else
            {
                effector.rotationalOffset = 0f;
            }
        }
    }
}
