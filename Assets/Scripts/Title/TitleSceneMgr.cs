using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneMgr : MonoBehaviour
{
    public enum state
    {
        LOGO,
        TITLE,
        TRANSITION,
    }

    private state curState = state.LOGO;
    public state CurState
    {
        get { return curState; }

        set
        {
            curState = value;
            switch(curState)
            {
                case state.TITLE:
                    titleCanvas.SetActive(true);
                    logoCanvas.SetActive(false);
                    break;

                case state.TRANSITION:
                    iris.nextSceneName = "MainMenu";
                    StopCoroutine(coBlink);
                    iris.gameObject.SetActive(true);
                    break;

                default:
                    break;
            }
        }
    }

    public GameObject logoCanvas;
    public GameObject titleCanvas;

    public IrisSceneTransition iris;
    public GameObject text;

    Coroutine coBlink;
    public float blinkInterval;

    AsyncOperation asyncLoad;

    private void Start()
    {
        asyncLoad = iris.GetComponent<IrisSceneTransition>().asyncLoad;
    }

    void Update()
    {
        if (coBlink == null)
            coBlink = StartCoroutine(CoBlink());

        if (CurState == state.TITLE && Input.anyKey)
        {
            CurState = state.TRANSITION;
        }
    }

    IEnumerator CoBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);

            text.SetActive(!text.activeSelf);
        }
    }
}
