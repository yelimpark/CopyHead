 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionIn : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        GameManager.Instnace.CurState = GameState.INTRO;
        gameObject.SetActive(false);
    }
}
