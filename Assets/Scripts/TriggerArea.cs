using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    public int doorID;
    private void OnTriggerEnter(Collider other)
    {
        TVControls_EventSystem.current.DoorwayTriggerEnter(doorID);
    }

    private void OnTriggerExit(Collider other)
    {
        TVControls_EventSystem.current.DoorwayTriggerExit(doorID);
    }
}
