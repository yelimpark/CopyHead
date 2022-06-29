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
    public int curPahse = 0;
    public int pahseNum;
    public List<GameObject> PhaseBoss = new List<GameObject>();
    public GameObject player;
    public BossSceneUI UI;

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
                    PhaseBoss[0].GetComponent<Animator>().SetTrigger("intro");
                    player.GetComponent<Animator>().SetTrigger("Intro");
                    break;
                case GameState.INGAME:
                    player.GetComponent<BossScenePlayerMove>().enabled = true;
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
        curPahse = 0;
        this.pahseNum = pahseNum;
        player = null;
        PhaseBoss.Clear();
    }
}
