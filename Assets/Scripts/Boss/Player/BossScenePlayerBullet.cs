using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerBullet : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
