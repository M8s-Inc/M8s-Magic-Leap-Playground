using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private MLInput.Controller controller;
    public GameObject headLockedCanvas;
    public GameObject controllerInput;

    public GameObject controllerCanvas;
    public GameObject[] objects;
    public GameObject[] objectsText;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
        controllerCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.TriggerValue > 0.5f)
        {
            RaycastHit hit;
            if(Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                if(hit.transform.gameObject.name == "StartButton")
                {
                    StartApp();
                }
            }
        }
    }

    void StartApp()
    {
        headLockedCanvas.SetActive(false);
        controllerCanvas.SetActive(true);
    }


    void UpdateTouchPad()
    {
        if(controller.Touch1Active)
        {
            float x = controller.Touch1PosAndForce.x;
            float y = controller.Touch1PosAndForce.y;
            float force = controller.Touch1PosAndForce.z;

            Debug.Log(" Update Touch Pad: X" + x + " Y : " + y + " Force : " + force);

            if(force > 0)
            {
                //are these right?
                if( x < 0.2 && y > 0.2) //top left
                {
                    //controllerInput.GetComponent<PlaceObject>().ObjectToPlace = Objects[0];
                    objectsText[0].GetComponent<TextMeshProUGUI>().color = Color.red;
                    objectsText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[2].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[3].GetComponent<TextMeshProUGUI>().color = Color.white;

                }
                else if (x > 0.2 && y > 0.2)// top right
                {
                    //controllerInput.GetComponent<PlaceObject>().ObjectToPlace = Objects[1];
                    objectsText[1].GetComponent<TextMeshProUGUI>().color = Color.red;
                    objectsText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[2].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[3].GetComponent<TextMeshProUGUI>().color = Color.white;
                }
                else if (x > 0.2 && y <  -0.2)//bottom right
                {
                    //controllerInput.GetComponent<PlaceObject>().ObjectToPlace = Objects[2];
                    objectsText[2].GetComponent<TextMeshProUGUI>().color = Color.red;
                    objectsText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[3].GetComponent<TextMeshProUGUI>().color = Color.white;
                }
                else if (x < -0.2 && y < -0.2)//bottom left
                {
                    //controllerInput.GetComponent<PlaceObject>().ObjectToPlace = Objects[3];
                    objectsText[3].GetComponent<TextMeshProUGUI>().color = Color.red;
                    objectsText[0].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[1].GetComponent<TextMeshProUGUI>().color = Color.white;
                    objectsText[2].GetComponent<TextMeshProUGUI>().color = Color.white;
                }
            }
        }
    }


    private void OnDestroy()
    {
        MLInput.Stop();
    }
}
