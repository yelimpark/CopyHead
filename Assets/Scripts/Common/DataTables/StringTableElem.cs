using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringTableElem : DataTableElem
{
    public string[] value;

    public override void Init(Dictionary<string, string> data)
    {
        value = new string[GameVal.ToTalLanguage];
        value[(int)Languages.Korean] = data["KOR"];
        value[(int)Languages.English] = data["ENG"];
    }
}
