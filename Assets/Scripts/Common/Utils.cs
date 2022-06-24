using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static int GetIntAxis(float axis)
    {
        if (axis > 0)
        {
            return 1;
        }
        else if (axis < 0)
        {
            return -1;
        }

        return 0;
    }
}
