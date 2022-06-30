using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    TRANSITION_IN,
    INTRO,
    INGAME,
    GAMEOVER,
    OUTRO,
    TRANSITION_OUT,
    COUNT
}

public class GameManager : Singleton<GameManager>
{
    public GameObject FirstPhaseBoss;
    public GameObject player;
    public GameObject playerIntro;
    public BossSceneUI UI;
    public int curPhase;

    private GameState curState = GameState.TRANSITION_IN;

    public GameState CurState {
        get { return curState; }
        set 
        {
            curState = value; 

            switch(curState)
            {
                case GameState.INTRO:
                    UI.CurState = GameState.INTRO;
                    FirstPhaseBoss.GetComponent<Animator>().SetTrigger("intro");
                    playerIntro.GetComponent<Animator>().SetTrigger("intro");
                    break;
                case GameState.INGAME:
                    playerIntro.SetActive(false);
                    player.SetActive(true);
                    UI.CurState = GameState.INGAME;
                    break;
                case GameState.GAMEOVER:
                    UI.CurState = GameState.GAMEOVER;
                    break;
                case GameState.OUTRO:
                    UI.CurState = GameState.OUTRO;
                    break;
                case GameState.TRANSITION_OUT:
                    UI.CurState = GameState.TRANSITION_OUT;
                    break;
                default:
                    break;
            }
        }
    }

    public void Init (int pahseNum)
    {
        curPhase = 0;
        player = null;
        curState = GameState.TRANSITION_IN;
    }
}
