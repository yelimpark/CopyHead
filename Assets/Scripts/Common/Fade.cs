using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade
{
    public static IEnumerator CoFadeIn(Renderer renderer, float transitionTime)
    {
        Color c = renderer.material.color;
        c.a = 255;

        while (renderer.material.color.Equals(c))
        {
            Color.Lerp(renderer.material.color, c, Time.deltaTime / transitionTime);
            yield return null;
        }
    }

    public static IEnumerator CoFadeIn(CanvasGroup canvasGroup, float transitionTime)
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime / transitionTime;
            yield return null;
        }
    }

    public static IEnumerator CoFadeOut(CanvasGroup canvasGroup, float transitionTime)
    {
        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / transitionTime;
            yield return null;
        }
        canvasGroup.gameObject.SetActive(false);
    }
}
