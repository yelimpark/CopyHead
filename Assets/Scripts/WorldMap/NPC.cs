using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPC : Interactable
{
    public NpcUIController npcUI;
    public string npcName;

    [System.NonSerialized]
    public int stateIdx = 0;
    [System.NonSerialized]
    public int stateIdxMax;

    public float cameraMovingSpeed;

    private void Start()
    {
        var npcTable = DataTableMgr.Instnace.GetTable<NPCTableElem>(DataTableTypes.NPC_TABLE);
        stateIdxMax = npcTable.GetDatas().Where(x => x.Value.name == npcName).Last().Value.state;
    }

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
