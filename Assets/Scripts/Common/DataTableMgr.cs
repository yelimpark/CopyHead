using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataTableTypes
{
    STRING_TABLE,
    NPC_TABLE,
    ITEM_TABLE
}

public class DataTableMgr : Singleton<DataTableMgr>
{
    private static Dictionary<DataTableTypes, DataTable> tables = new Dictionary<DataTableTypes, DataTable>();

    public DataTableMgr()
    {
        var stringTable = new DataTable<StringTableElem>();
        stringTable.Load("Tables/StringTable");
        tables.Add(DataTableTypes.STRING_TABLE, stringTable);

        var npcTable = new DataTable<NPCTableElem>();
        npcTable.Load("Tables/NPCTable");
        tables.Add(DataTableTypes.NPC_TABLE, npcTable);
    }

    public DataTable<T> GetTable<T>(DataTableTypes type) where T : DataTableElem, new()
    {
        if (!tables.ContainsKey(type))
        {
            return null;
        }

        return tables[type] as DataTable<T>;
    }
}
