using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataTableElem
{
    public abstract void Init(Dictionary<string, string> data);
}

public abstract class DataTable
{
    public abstract void Load(string path);
}

public class DataTable<T> : DataTable where T : DataTableElem, new()
{
    protected Dictionary<string, T> data = new Dictionary<string, T>();

    public override void Load(string path)
    {
        var list = CSVReader.Read(path);
        foreach (var line in list)
        {
            T elem = new T();
            elem.Init(line);
            data.Add(line["ID"], elem);
        }
    }

    public T GetData(string id)
    {
        if (!data.ContainsKey(id))
            return null;

        return data[id];
    }

    public Dictionary<string, T> GetDatas()
    {
        return data;
    }
}