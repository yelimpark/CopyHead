using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class GamOverUI : MonoBehaviour
{
    public IrisSceneTransition iris;

    public GameObject textImg;
    
    public GameObject card;
    public Image mugshot;
    public TextMeshProUGUI lineText;
    public GameObject firstMenu;
    public List<Sprite> mugshots = new List<Sprite>();

    public float delay = 3f;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstMenu);
    }

    public void SelectRetry()
    {
        string curSceneName = SceneManager.GetActiveScene().name;
        SelectMenu(curSceneName);
    }

    public void SelectExit()
    {
        SelectMenu("WorldMap");
    }

    public void SelectQuit()
    {
        iris.nextSceneName = "Title";
        iris.gameObject.SetActive(true);
    }

    void SelectMenu(string nextscene)
    {
        Loading.nextSceneName = nextscene;
        iris.nextSceneName = "Loading";
        iris.gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        if (GameManager.Instnace.CurState == GameState.GAMEOVER)
        {
            int phase = GameManager.Instnace.curPhase;
            mugshot.sprite = mugshots[phase];
            //lineText.text = "";
            StartCoroutine(Utils.CoWait(delay, ShowCard));
        }
    }

    public void ShowCard()
    {
        textImg.SetActive(false);
        card.SetActive(true);
    }
}
