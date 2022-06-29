using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSceneUI : MonoBehaviour
{
    private GameState curState = GameState.TRANSITION_IN;

    public GameState CurState
    {
        get { return curState; }
        set
        {
            curState = value;

            switch (curState)
            {
                case GameState.INTRO:
                    uiArr[(int)GameState.INTRO].SetActive(true);
                    break;
                case GameState.GAMEOVER:
                    healthImg.sprite = healthSprites[0];
                    uiArr[(int)GameState.GAMEOVER].SetActive(true);
                    break;
                case GameState.OUTRO:
                    uiArr[(int)GameState.OUTRO].SetActive(true);
                    break;
                case GameState.TRANSITION_OUT:
                    uiArr[(int)GameState.TRANSITION_OUT].SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    public Image healthImg;
    public Sprite[] healthSprites = new Sprite[5];
    public BossSceneAttackablePlayer player;
    public GameObject[] uiArr = new GameObject[(int)GameState.COUNT];

    int life = 0;

    private void Start()
    {
        GameManager.Instnace.UI = this;
    }

    void Update()
    {
        if (player != null & player.Life != life)
        {
            life = player.Life;
            healthImg.sprite = healthSprites[life];
        }
    }
}
