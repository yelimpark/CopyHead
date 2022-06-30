using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScenePlayerIntro : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instnace.playerIntro = gameObject;
    }

    public void OnIntroEnd()
    {
        GameManager.Instnace.CurState = GameState.INGAME;
    }
}
