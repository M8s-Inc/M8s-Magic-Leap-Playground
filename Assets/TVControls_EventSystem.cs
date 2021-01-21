using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TVControls_EventSystem : MonoBehaviour
{

    public static TVControls_EventSystem current;

    public void Awake()
    {
        current = this;

    }


    public event Action<int> onDoorwayTriggerEnter;

    public void DoorwayTriggerEnter(int id)
    {
        if(onDoorwayTriggerEnter != null)
        {
            onDoorwayTriggerEnter(id);

        }
    }

    public event Action<int> OnDoorwayTriggerExit;
    public void DoorwayTriggerExit(int id)
    {
        if (OnDoorwayTriggerExit != null)
        {
            OnDoorwayTriggerExit(id);

        }
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

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
}
