using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrisSceneTransition : MonoBehaviour
{
    [System.NonSerialized]
    public string nextSceneName = string.Empty;

    [System.NonSerialized]
    public AsyncOperation asyncLoad;

    public void OnTransitionEnd()
    {
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator LoadMyAsyncScene()
    {
        asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    private void OnEnable()
    {
        if (nextSceneName != string.Empty)
            StartCoroutine(LoadMyAsyncScene());
    }
}
