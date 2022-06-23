using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcUIController : MonoBehaviour
{
    public PlayerWorldMapMove player;
    public GameObject talk;

    private void OnEnable()
    {
        player.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.enabled = true;
            talk.SetActive(false);
            Camera.main.GetComponent<FollowTarget>().enabled = true;
            gameObject.SetActive(false);
        }
    }
}
