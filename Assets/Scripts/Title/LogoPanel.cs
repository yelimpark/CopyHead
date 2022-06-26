using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoPanel : MonoBehaviour
{
    public TitleSceneMgr titleSceneMgr;

    public void OnLogoAnimEnd()
    {
        titleSceneMgr.CurState = TitleSceneMgr.state.TITLE;
    }
}
