using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public NpcUIController npcUI;
    public string npcName;

    public float cameraMovingSpeed;

    void Update()
    {
        if (Active && Input.GetKeyDown(KeyCode.Z))
        {
            Active = false;
            npcUI.npc = this;
            npcUI.gameObject.SetActive(true);
            Camera.main.GetComponent<FollowTarget>().enabled = false;
            iTween.MoveTo(Camera.main.gameObject, iTween.Hash(
                "x", transform.position.x,
                "y", transform.position.y,
                "speed", cameraMovingSpeed
            ));
        }
    }
}
