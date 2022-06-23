using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerAttack : MonoBehaviour
{
    Animator animator;

    public float spawnInterval = 0.7f;
    float timer = 0f;

    public GameObject bulletPrefab;
    GameObject[] bullets = new GameObject[25];
    int idx = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
        timer = spawnInterval;
    }

    void Update()
    {
        timer = Mathf.Min(timer + Time.deltaTime, spawnInterval);

        if (animator.GetBool("X") && timer == spawnInterval)
        {
            timer = 0f;
            bullets[idx].transform.position = transform.position;
            
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            Vector3 dir = new Vector3(h, v, 0f);
            dir.Normalize();

            var look = new Vector3(0f, 0f, Vector3.Angle(dir, Vector3.right));
            bullets[idx].transform.rotation = Quaternion.Euler(look);

            iTween.MoveTo(bullets[idx], iTween.Hash(
                "position", dir * 100,
                "speed", 3f
            ));

            bullets[idx].SetActive(true);
            idx++;
        }
    }
}
