using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Reflection;

public class NpcUIController : MonoBehaviour
{
    public PlayerWorldMapMove player;
    public DefaultUIController defaultUIController;

    public GameObject talk;
    public GameObject coin;
    public TextMeshProUGUI line;

    [System.NonSerialized]
    public NPC npc = null;

    DataTable<NPCTableElem> npcTable;
    IEnumerable<KeyValuePair<string, NPCTableElem>> query;
    IEnumerator<KeyValuePair<string, NPCTableElem>> idx;

    private void Awake()
    {
        npcTable = DataTableMgr.Instnace.GetTable<NPCTableElem>(DataTableTypes.NPC_TABLE);
    }

    private void OnEnable()
    {
        player.enabled = false;
        if (npc != null && npcTable != null)
        {   
            query = npcTable.GetDatas().Where(x => x.Value.name == npc.npcName && x.Value.state == npc.stateIdx);
            idx = query.GetEnumerator();
            HandleNPCData();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            disableEverychild();
            HandleNPCData();
        }
    }

    void HandleNPCData()
    {
        if (!idx.MoveNext())
        {
            OnLineEnd();
            return;
        }

        switch (idx.Current.Value.type)
        {
            case NpcDataType.L:
                talk.SetActive(true);
                line.text = idx.Current.Value.Line;
                break;
            case NpcDataType.E:
                string functionName = idx.Current.Value.function;
                var type = this.GetType();
                MethodInfo func = type.GetMethod(functionName, BindingFlags.Instance | BindingFlags.Public);
                func.Invoke(this, null);
                break;
            default:
                break;
        }
    }

    private void OnLineEnd()
    {
        player.enabled = true;
        gameObject.SetActive(false);

        var itween = Camera.main.GetComponent<iTween>();
        if (itween != null)
            Destroy(itween);

        Camera.main.GetComponent<FollowTarget>().enabled = true;
        npc.stateIdx = Mathf.Min(npc.stateIdxMax, npc.stateIdx + 1);
    }

    public void GetThreeCoin()
    {
        coin.SetActive(true);
        GameVal.Instnace.coin += 3;
        defaultUIController.OnCoinChange();
    }

    public void disableEverychild()
    {
        talk.SetActive(false);
        coin.SetActive(false);
    }
}
