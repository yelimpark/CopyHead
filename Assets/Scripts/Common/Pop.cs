using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop
{
    public static IEnumerator CoPopUp(GameObject obj, float transitionTime)
    {
        while (!obj.transform.localScale.Equals(Vector3.one))
        {
            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, Vector3.one, Time.deltaTime / transitionTime);
            yield return null;
        }
    }

    public static IEnumerator CoPopDown(GameObject obj, float transitionTime)
    {
        while (!obj.transform.localScale.Equals(Vector3.zero))
        {
            obj.transform.localScale = Vector3.Lerp(obj.transform.localScale, Vector3.zero, Time.deltaTime / transitionTime);
            yield return null;
        }
    }
}
