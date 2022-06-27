using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : Interactable
{
    public MiniCardUIController miniCard;
    public MiniCardDefinition def;

    void Update()
    {
        if (Active && Input.GetKeyDown(KeyCode.Z))
        {
            miniCard.def = def;
            miniCard.gameObject.SetActive(true);
        }
    }
}
