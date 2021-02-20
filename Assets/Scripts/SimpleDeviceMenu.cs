using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using TMPro;

public class SimpleDeviceMenu : MonoBehaviour
{
    private MLInput.Controller controller;
    public GameObject SimpleDeviceCanvas;
    public GameObject controllerInput;

    public GameObject lightObject;
    public GameObject tvObject;

    //Don't need this right now.
    //public GameObject controllerCanvas;
    //public GameObject[] objectsText;
    //public GameObject[] objects;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
        //controllerCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.TriggerValue > 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                if (hit.transform.gameObject.name == "LightButton")
                {
                    controllerInput.GetComponent<PlaceObject>().objectToPlace = lightObject;
                }
                if (hit.transform.gameObject.name == "TVButton")
                {
                    controllerInput.GetComponent<PlaceObject>().objectToPlace = tvObject;
                }
            }
        }
    }
    
    private void OnDestroy()
    {
        MLInput.Stop();
    }
}
