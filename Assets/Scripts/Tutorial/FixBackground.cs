using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBackground : MonoBehaviour
{
    public GameObject player;
    
    Vector3 offset;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    void Update()
    {
        transform.position = player.transform.position - offset;
    }
}
