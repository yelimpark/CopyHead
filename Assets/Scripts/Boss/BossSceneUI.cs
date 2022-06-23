using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSceneUI : MonoBehaviour
{
    public Image healthImg;
    public Sprite[] healthSprites = new Sprite[5];
    public BossSceneAttackablePlayer player;
    public GameObject GameOver;

    int life = 0;

    void Update()
    {
        if (player != null & player.Life != life)
        {
            life = player.Life;
            healthImg.sprite = healthSprites[life];
        }
        if (player == null)
        {
            healthImg.sprite = healthSprites[0];
            GameOver.SetActive(true);
        }
    }
}
