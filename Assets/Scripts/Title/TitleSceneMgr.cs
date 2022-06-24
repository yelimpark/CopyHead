using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneMgr : MonoBehaviour
{
    public GameObject LogoCanvas;
    public GameObject TitleCanvas;

    AsyncOperation asyncLoad;

    void Start()
    {
        StartCoroutine(LoadMyAsyncScene());
    }

    IEnumerator LoadMyAsyncScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync("MainMenu");
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    public void OnLogoAnimEnd()
    {
        TitleCanvas.SetActive(true);
        LogoCanvas.SetActive(false);
    }


}
