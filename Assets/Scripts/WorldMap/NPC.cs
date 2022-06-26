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
        if (Active && Input.GetKeyDown(KeyCode.Z))
        {
            Active = false;
            talk.SetActive(true);
            npcUI.SetActive(true);
            Camera.main.GetComponent<FollowTarget>().enabled = false;
            iTween.MoveTo(Camera.main.gameObject, iTween.Hash(
                "x", transform.position.x,
                "y", transform.position.y,
                "speed", cameraMovingSpeed
            ));
        }
    }
}
