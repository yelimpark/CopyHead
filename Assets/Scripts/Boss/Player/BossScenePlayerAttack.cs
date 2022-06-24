using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerAttack : MonoBehaviour
{
    Animator animator;

    public float spawnInterval = 0.7f;
    float timer = 0f;

    public GameObject spawnPoint;

    public GameObject bulletPrefab;
    GameObject[] bullets = new GameObject[15];
    int idx = 0;

    public float bulletYDistance = 0.2f;

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

    void LateUpdate()
    {
        var currentAnimation = animator.GetCurrentAnimatorStateInfo(0);
        if (currentAnimation.IsName("cuphead_Duck"))
        {
            return;
        }

        timer = Mathf.Min(timer + Time.deltaTime, spawnInterval);

        if (animator.GetBool("X") && timer == spawnInterval && animator)
        {
            timer = 0f;

            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");

            Vector3 pos = spawnPoint.transform.position;
            
            pos.y += (idx % 2 == 0 && v == 0) ? bulletYDistance : 0;
            pos.x += (idx % 2 == 0 && h == 0) ? bulletYDistance : 0;

            if (h == 0)
                pos.x += (transform.localScale.x > 0) ? 0.1f : -0.3f;
            
            bullets[idx].transform.position = pos;
            bullets[idx].SetActive(true);
            idx = (idx == bullets.Length - 1)? 0 : idx + 1;
        }
    }
}
