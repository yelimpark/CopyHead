using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerryingZone : MonoBehaviour
{
    public List<GameObject> perryObjs = new List<GameObject>();
    int idx = 0;

    void Update()
    {
        if (perryObjs[idx].activeSelf == false)
        {
            idx = (idx == perryObjs.Count - 1)? 0 : idx + 1;
            perryObjs[idx].SetActive(true);
        }
    }
}
