using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUIController : MonoBehaviour
{
    public GameObject text;
    public float blinkInterval = 0.5f;

    public GameObject Iris;

    void OnEnable()
    {
        StartCoroutine(Blink());
    }

    void Update()
    {
        if (asyncLoad == null)
            return;

        if (asyncLoad.isDone && Input.anyKey)
        {
            Iris.SetActive(true);
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkInterval);

            text.SetActive(!text.activeSelf);
            Debug.Log(text.activeSelf);
        }
    }

    public void OnTransitionEnd()
    {
        asyncLoad.allowSceneActivation = true;
        StopAllCoroutines();
    }
}
