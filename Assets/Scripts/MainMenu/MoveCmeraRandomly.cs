using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCmeraRandomly : MonoBehaviour
{
    public Transform CameraArea;
    public float speed;

    Vector2 CameraPosMax;

    Vector3 dir;

    private void Start()
    {
        CameraPosMax.x = CameraArea.localScale.x * 0.5f - Camera.main.orthographicSize * Screen.width / Screen.height;
        CameraPosMax.y = CameraArea.localScale.y * 0.5f - Camera.main.orthographicSize;

        dir = new Vector3(1, 1, 0);
        dir.Normalize();
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

        if (transform.position.x > CameraPosMax.x || transform.position.x < CameraPosMax.x * (-1))
        {
            dir.x = (-1) * dir.x;
            dir.Normalize();
        }

        if (transform.position.y > CameraPosMax.y || transform.position.y < CameraPosMax.y * (-1))
        {
            dir.y = (-1) * dir.y;
            dir.Normalize();
        }
    }
}
