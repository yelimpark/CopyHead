using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : Interactable
{
    public IrisSceneTransition iris;
    public string nextSceneName;

    void Start()
    {
        Utils.LocateUIAtPos(gameObject, speechBubble);
    }

    void Update()
    {
        if (Active)
        {
            Utils.LocateUIAtPos(gameObject, speechBubble);
            speechBubble.transform.position -= Camera.main.transform.position;
        }

        if (Active && Input.GetKeyDown(KeyCode.Z))
        {
            Active = false;
            Loading.nextSceneName = nextSceneName;
            iris.nextSceneName = "Loading";
            iris.gameObject.SetActive(true);
        }
    }
}
