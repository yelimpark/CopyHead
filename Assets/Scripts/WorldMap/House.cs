using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class House : Interactable
{
    public GameObject miniCard;
    public MiniCardDefinition def;

    void Update()
    {
        if (Active && Input.GetKeyDown(KeyCode.Z))
        {
            miniCard.GetComponent<MiniCardUIController>().def = def;
            miniCard.SetActive(true);
        }
    }
}
