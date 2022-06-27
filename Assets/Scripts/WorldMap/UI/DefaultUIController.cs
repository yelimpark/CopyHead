using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUIController : MonoBehaviour
{
    public Image coinTextFirst;
    public Image coinTextSecond;

    public Sprite[] numberSprites = new Sprite[10];

    //public GameObject equipUI;

    void Start()
    {
        OnCoinChange();
    }

    public void OnCoinChange() {
        int coin = GameVal.Instnace.coin;

        int firsrDigit = coin / 10;
        int secondDigit = coin % 10;

        coinTextFirst.sprite = numberSprites[firsrDigit];
        coinTextSecond.sprite = numberSprites[secondDigit];
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
    //    {
    //        //equipUI.SetActive(true);
    //    }
    //}
}
