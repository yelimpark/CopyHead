using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveAtAnimEnd : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        gameObject.SetActive(false);
    }
}
