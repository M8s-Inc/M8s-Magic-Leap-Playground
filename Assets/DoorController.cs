using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{

    public int DoorID;

    // Start is called before the first frame update
    void Start()
    {
        //Subscribe to the action event and delegate it to the onDoorwayOpen method. 
        TVControls_EventSystem.current.onDoorwayTriggerEnter += OnDoorwayOpen;
        TVControls_EventSystem.current.onDoorwayTriggerEnter += OnDoorwayClose;

    }

    private void OnDoorwayOpen(int id)
    {

        //call some function
        if(id == DoorID)
        {
            Debug.Log("Open the door");
        }
    }

    private void OnDoorwayClose(int id)
    {

        //call some function
        if (id == DoorID)
        {
            Debug.Log("Close the door");
        }
    }

    private void OnDestroy()
    {
        TVControls_EventSystem.current.onDoorwayTriggerEnter -= OnDoorwayOpen;
        TVControls_EventSystem.current.onDoorwayTriggerEnter -= OnDoorwayClose;
    }
}
