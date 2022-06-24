using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerBullet : MonoBehaviour
{
    private GameObject player;

    public float posOffset = 0.5f;
    public float speed = 3f;
    public int damage = 1;
    
    Vector3 dir;
    bool isColieded = false;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Animator animator = player.GetComponent<Animator>();

        dir = Vector3.zero;
        dir.x = Utils.GetIntAxis(Input.GetAxisRaw("Horizontal"));

        if (!animator.GetBool("Duckable"))
        {
            dir.x = player.transform.localScale.x;
        }
        else
        {
            dir.y = Utils.GetIntAxis(Input.GetAxisRaw("Vertical"));

            if (dir.y == 0 && dir.x == 0)
            {
                dir.x = player.transform.localScale.x;
            }
        }

        var angle = Mathf.Atan2(dir.x, dir.y * (-1)) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        dir.Normalize();
        transform.position += dir * posOffset;
    }

    private void Update()
    {
        if (isColieded) return;
        transform.position += dir * speed * Time.deltaTime; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Attackable>().OnHitted(damage);
        }

        isColieded = true;
        animator.SetTrigger("Blow");
    }

    public void OnVFXEnd()
    {
        isColieded = false;
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        isColieded = false;
        gameObject.SetActive(false);
    }
}
