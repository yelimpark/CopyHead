using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIController : MonoBehaviour
{
    public List<TextMeshProUGUI> menus = new List<TextMeshProUGUI>();

    public Color ActiveColor;
    public Color DeactiveColor;

    int idx = 0;
    public int Idx
    {
        get { return idx; }
        set 
        {
            menus[idx].color = DeactiveColor;
            idx = value;
            menus[idx].color = new Color(255f, 255f, 255f);
        }
    }

    void Start()
    {
        Idx = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            switch(Idx)
            {
                case 0:
                    Loading.nextSceneName = "WorldMap";
                    SceneManager.LoadScene("Loading");
                    break;
                case 1:

                    break;
                default:
                    Application.Quit();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Idx = Mathf.Max(Idx - 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Idx = Mathf.Min(Idx + 1, menus.Count - 1);
        }
    }
}
