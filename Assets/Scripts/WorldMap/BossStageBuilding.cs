using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageBuilding : Interactable
{
    public GameObject BossStageUI;
    public BuildingDefinition def;

    private void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.Z))
        {
            BossStageUI.GetComponent<BossStageUIController>().def = def;
            BossStageUI.SetActive(true);
        }
    }
}
