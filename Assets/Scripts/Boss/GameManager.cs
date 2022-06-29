using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int curPahse = 0;
    public int pahseNum;
    public List<GameObject> PhaseBoss = new List<GameObject>();
    public GameObject player;

    public enum state
    {
        TRANSITION_IN,
        INTRO,
        INGAME,
        OUTRO,
        TRANSITION_OUT
    }

    public state curState = state.TRANSITION_IN;

    public void Init (int pahseNum)
    {
        curPahse = 0;
        this.pahseNum = pahseNum;
        player = null;
        PhaseBoss.Clear();
    }
}
