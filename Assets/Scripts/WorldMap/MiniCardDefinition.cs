using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WorldMap/MiniCard", fileName = "MiniCard.asset")]
public class MiniCardDefinition : ScriptableObject
{
    public string nextSceneName;
    public string titleStr;
}