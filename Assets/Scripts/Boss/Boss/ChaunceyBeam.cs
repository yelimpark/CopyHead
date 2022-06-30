using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaunceyBeam : AttackPlayer
{
    public float speed;
    public Transform player;
    Vector3 dir;

    void Start()
    {
        if (player != null)
        {
            dir = player.position - transform.position;
            dir.Normalize();
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
            transform.rotation = angleAxis;
        }

        IsDestroyable = true;
    }

    public void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    public override void HandleDestroy(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }
    }
}
