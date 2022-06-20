using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageBuliding : Interactable
{
    public GameObject BossStageUI;

    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.Z))
        {
            BossStageUI.SetActive(true);
        }
    }
}
