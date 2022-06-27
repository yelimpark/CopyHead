using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WorldMap/Building", fileName = "Building.asset")]
public class BuildingDefinition : ScriptableObject
{
    public string bossSceneName;
    public Sprite cardTextSprite;
}
