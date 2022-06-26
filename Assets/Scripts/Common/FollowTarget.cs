using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform CameraArea;
    public Transform target;
    public float speed = 4f;

    public bool followY = true;
    public bool followX = true;

    Vector2 CameraPosMix;
    Vector2 CameraPosMax;

    public Vector3 offset;

    void Start()
    {
        CameraPosMix = CameraArea.localScale * 0.5f;

        CameraPosMix.x -= Camera.main.orthographicSize * Screen.width / Screen.height + CameraArea.position.x;
        CameraPosMix.y -= Camera.main.orthographicSize + CameraArea.position.y;

        CameraPosMix *= -1f;

        CameraPosMax = CameraArea.position + CameraArea.localScale * 0.5f;
        CameraPosMax.x -= Camera.main.orthographicSize * Screen.width / Screen.height;
        CameraPosMax.y -= Camera.main.orthographicSize;
    }

    void LateUpdate()
    {
        Vector3 endPos = target.position + offset;

        endPos.y = Mathf.Clamp(endPos.y, CameraPosMix.y, CameraPosMax.y);
        endPos.x = Mathf.Clamp(endPos.x, CameraPosMix.x, CameraPosMax.x);

        if (!followY)
        {
            endPos.y = transform.position.y;
        }
        if (!followX)
        {
            endPos.x = transform.position.x;
        }

        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime * speed);
    }
}
