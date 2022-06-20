using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossStageUIController : MonoBehaviour
{
    public GameObject[] difficulties = new GameObject[2];
    int CurDifficulty = 1;

    public GameObject card;
    public float TransitionTime = 1f;

    CanvasGroup canvasGroup;

    public PlayerWorldMapMove player;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        player.enabled = false;
        iTween.ScaleTo(card, iTween.Hash(
            "scale", Vector3.one,
            "time", TransitionTime,
            "easetype", iTween.EaseType.easeOutBack
        ));
        StartCoroutine(Fade.CoFadeIn(canvasGroup, TransitionTime));
    }

    void SetDifficulty(int offset)
    {
        difficulties[CurDifficulty].SetActive(false);
        CurDifficulty += offset;
        difficulties[CurDifficulty].SetActive(true);
    }

    void Update()
    {
        if (canvasGroup.alpha < 1) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Fade.CoFadeOut(canvasGroup, TransitionTime * 0.5f));
        }

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
            
        }
    }

    private void OnDisable()
    {
        card.transform.localScale = Vector3.zero;
        player.enabled = true;
    }
}
