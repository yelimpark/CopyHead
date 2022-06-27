using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStageBuilding : Interactable
{
    public BossStageUIController BossStageUI;
    public BuildingDefinition def;

    private void Update()
    {
        if (Active && Input.GetKeyDown(KeyCode.Z))
        {
            BossStageUI.def = def;
            BossStageUI.gameObject.SetActive(true);
        }
    }
}
