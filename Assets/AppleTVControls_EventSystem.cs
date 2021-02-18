using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AppleTVControls_EventSystem : MonoBehaviour
{

    public static AppleTVControls_EventSystem current;

    public void Awake()
    {
        current = this;

    }

    public event Action<int> onXRButtonPressed;

    public void XRButtonPressed(int id)
    {
        if (onXRButtonPressed != null)
        {
            onXRButtonPressed(id);
        }
    }

    public event Action<int> onXRButtonReleased;

    public void XRButtonReleased(int id)
    {
        if (onXRButtonReleased != null)
        {
            onXRButtonReleased(id);
        }
    }
}
