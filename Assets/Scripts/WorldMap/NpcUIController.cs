using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class NpcUIController : MonoBehaviour
{
    public PlayerWorldMapMove player;
    public GameObject talk;
    public TextMeshProUGUI line;

    [System.NonSerialized]
    public string npcName = "Apple";

    DataTable<NPCTableElem> npcTable;
    IEnumerable<KeyValuePair<string, NPCTableElem>> query;

    private void Awake()
    {
        npcTable = DataTableMgr.Instnace.GetTable<NPCTableElem>(DataTableTypes.NPC_TABLE);
    }

    private void OnEnable()
    {
        player.enabled = false;

        if (npcName != null && npcTable != null)
        {   
            query = npcTable.GetDatas().Where(x => x.Value.name == npcName);
        }
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
