using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameVal : Singleton<GameVal>
{
    public int MaxLife = 3;
    public int coin = 0;

    public GameVal()
    {
        //var path = Path.Combine(Application.persistentDataPath, "GameVal.dat");
        //var json = File.ReadAllText(path);
        //JsonUtility.FromJsonOverwrite(json, this);
    }

    public void OnSave()
    {
        var path = Path.Combine(Application.persistentDataPath, "GameVal.dat");
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(path, json);
    }
}
