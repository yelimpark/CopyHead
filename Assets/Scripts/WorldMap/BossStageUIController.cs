using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossStageUIController : UICard
{
    public GameObject[] difficulties = new GameObject[2];
    int CurDifficulty = 1;

    public Image cardText;

    [System.NonSerialized]
    public BuildingDefinition def;

    public override void OnEnable()
    {
        base.OnEnable();

        if (def != null)
            cardText.sprite = def.cardTextSprite;
    }

    void SetDifficulty(int offset)
    {
        difficulties[CurDifficulty].SetActive(false);
        CurDifficulty += offset;
        difficulties[CurDifficulty].SetActive(true);
    }

    public override void Update()
    {
        base.Update();

        if (canvasGroup.alpha < 1) return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && CurDifficulty > 0)
        {
            SetDifficulty(-1);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && CurDifficulty < difficulties.Length -1)
        {
            SetDifficulty(1);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Loading.nextSceneName = def.bossSceneName;
            iris.nextSceneName = "Loading";
            iris.gameObject.SetActive(true);
        }
    }
}
