using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject speechBubble;

    protected bool active = false;
    public float TransitionTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            int isFilped = other.GetComponent<PlayerWorldMapMove>().IsFliped;
            active = true;
            iTween.ScaleTo(speechBubble, iTween.Hash(
                "scale", new Vector3(isFilped, 1f, 1f),
                "time", TransitionTime,
                "easetype", iTween.EaseType.easeInQuart
            ));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            active = false;
            iTween.ScaleTo(speechBubble, iTween.Hash(
                "scale", Vector3.zero,
                "time", TransitionTime,
                "easetype", iTween.EaseType.easeInQuart
            ));
        }
    }
}
