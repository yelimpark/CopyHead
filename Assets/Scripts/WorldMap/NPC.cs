using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public GameObject talk;
    public GameObject npcUI;

    public float cameraMovingSpeed;

    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.Z))
        {
            talk.SetActive(true);
            npcUI.SetActive(true);
            Camera.main.GetComponent<FollowTarget>().enabled = false;
            iTween.MoveTo(Camera.main.gameObject, iTween.Hash(
                "position", new Vector3(3.4f, 0f, -6.2f),
                "speed", cameraMovingSpeed
            ));
            iTween.ScaleTo(speechBubble, iTween.Hash(
                "scale", Vector3.zero,
                "time", TransitionTime,
                "easetype", iTween.EaseType.easeInQuart
            ));
        }
    }
}
