using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoastSpawner : MonoBehaviour
{
    public GameObject goast;

    void Update()
    {
        if (goast.activeSelf == false)
        {
            goast.GetComponent<Animator>().Rebind();
            goast.transform.position = transform.position;
            goast.GetComponent<CircleCollider2D>().enabled = true;
            goast.SetActive(true);
        }
    }
}
