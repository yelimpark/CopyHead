using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICard : MonoBehaviour
{
    public PlayerWorldMapMove player;
    public IrisSceneTransition iris;

    protected CanvasGroup canvasGroup;
    public GameObject card;

    public float TransitionTime = 1f;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public virtual void OnEnable()
    {
        player.enabled = false;
        iTween.ScaleTo(card, iTween.Hash(
            "scale", Vector3.one,
            "time", TransitionTime,
            "easetype", iTween.EaseType.easeOutBack
        ));
        StartCoroutine(Fade.CoFadeIn(canvasGroup, TransitionTime));
    }

    public virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Loading.nextSceneName = string.Empty;
            StartCoroutine(Fade.CoFadeOut(canvasGroup, TransitionTime * 0.5f));
        }
    }

    private void OnDisable()
    {
        card.transform.localScale = Vector3.zero;
        if (player != null)
            player.enabled = true;
    }
}
