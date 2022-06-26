using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject speechBubble;
    public bool onPlayer = true;

    private bool active = false;

    public bool Active
    {
        get { return active; }
        set
        {
            active = value;

            if (!active)
            {
                iTween.ScaleTo(speechBubble, iTween.Hash(
                    "scale", Vector3.zero,
                    "time", TransitionTime,
                    "easetype", iTween.EaseType.easeInQuart
                ));
            }
        }
    }

    public float TransitionTime = 0.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            float scaleX = 1f;

            if (onPlayer)
                scaleX = other.transform.localScale.x;

            active = true;
            iTween.ScaleTo(speechBubble, iTween.Hash(
                "scale", new Vector3(scaleX, 1f, 1f),
                "time", TransitionTime,
                "easetype", iTween.EaseType.easeInQuart
            ));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Active = false;
        }
    }
}
