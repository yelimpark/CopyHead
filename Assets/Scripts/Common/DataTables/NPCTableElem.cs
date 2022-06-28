using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NpcDataType {
    L,
    E
}

public class NPCTableElem : DataTableElem
{
    public string name;
    public int state;
    public NpcDataType type;
    public string line;
    public string function;

    public string Line
    {
        get { return DataTableMgr.Instnace.GetTable<StringTableElem>(DataTableTypes.STRING_TABLE).GetData(line).value[(int)GameVal.CurrentRanguage]; }
    }

    public override void Init(Dictionary<string, string> data)
    {
        name = data["NAME"];
        state = int.Parse(data["STATE"]);
        type = (NpcDataType)Enum.Parse(typeof(NpcDataType), data["TYPE"]);
        line = data["LINE"];
        function = data["FUNCTION"];
    }
}
