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
            gameObject.SetActive(false);

            var itween = Camera.main.GetComponent<iTween>();
            if (itween != null)
                Destroy(itween);

            Camera.main.GetComponent<FollowTarget>().enabled = true;
        }
    }
}
