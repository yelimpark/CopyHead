using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerGoast : MonoBehaviour
{
    public float speed = 3f;

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y > Camera.main.orthographicSize)
        {
            gameObject.SetActive(false);
        }
    }
}
