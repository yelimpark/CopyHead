using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public static string nextSceneName = string.Empty;

    void Start()
    {
        if (nextSceneName != string.Empty)
            StartCoroutine(LoadMyAsyncScene());
        else
            Debug.LogError("There is no NextScene's info");
    }

    IEnumerator LoadMyAsyncScene()
    {
        yield return new WaitForSeconds(3f);

        var asyncLoad = SceneManager.LoadSceneAsync(nextSceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
