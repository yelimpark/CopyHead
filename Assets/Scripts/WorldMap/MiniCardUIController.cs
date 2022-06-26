using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MiniCardUIController : UICard
{
    [System.NonSerialized]
    public MiniCardDefinition def;

    public TextMeshProUGUI titleText;

    public override void OnEnable()
    {
        base.OnEnable();

        if (def != null)
            titleText.text = def.titleStr;
        titleText.text = titleText.text.Replace("\\n", "\n");
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Loading.nextSceneName = def.nextSceneName;
            iris.nextSceneName = "Loading";
            iris.gameObject.SetActive(true);
        }
    }
}
