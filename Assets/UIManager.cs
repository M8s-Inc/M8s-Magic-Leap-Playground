using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using UnityEngine.UI;
using TMPro;

//public enum currentMenuPage
//{
//    closed,
//    mainMenu,
//    settingsMenu,
//    addDeviceMenu,
//    lightsMenu
//};

public class UIManager : MonoBehaviour
{

    private MLInput.Controller controller;
    public GameObject controllerInput;

    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject addDeviceCanvas;

    //public GameObject[] objects;
    //public GameObject[] objectsText;

    public GameObject currentMenuPage;
    public GameObject previousMenuPage;

    public bool menuClosed;

    public bool triggerPushed;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;

        menuClosed = true;

        triggerPushed = false;

        currentMenuPage = null;
        previousMenuPage = null;

        controller = MLInput.GetController(MLInput.Hand.Left);
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        addDeviceCanvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.TriggerValue > 0.5f && !triggerPushed)
        {
            RaycastHit hit;
            if (Physics.Raycast(controllerInput.transform.position, controllerInput.transform.forward, out hit))
            {
                if (hit.transform.gameObject.name == "SettingsMenu_Button")
                {
                    OpenPage(settingsCanvas);
                    triggerPushed = true;
                }
                else if (hit.transform.gameObject.name == "AddDeviceMenu_Button")
                {
                    OpenPage(addDeviceCanvas);
                    triggerPushed = true;
                }
                //do i even need this? I think i'll make do with the controller.
                else if (hit.transform.gameObject.name == "PreviousMenu_Button")
                {
                    OpenPreviousPage();
                    triggerPushed = true;
                }
            }
        }
        if (controller.TriggerValue < 0.2f)
        {
            triggerPushed = false;

        }
    }

    void OnButtonDown(byte controller_id, MLInput.Controller.Button button)
    {
        //actually I don't think i need bumper here... we'll see.
        if (button == MLInput.Controller.Button.Bumper)
        {
            //RaycastHit hit;
            //if (Physics.Raycast(controller.Position, transform.forward, out hit))
            //{
            //    //GameObject placeObject = Instantiate(objectToPlace, hit.point, Quaternion.Euler(hit.normal));
            //}
        }

        if (button == MLInput.Controller.Button.HomeTap)
        {

            //if (currentMenuPage == mainMenuCanvas)
            //{
            //    Debug.Log("back button on mainMenu first if");
            //    currentMenuPage.SetActive(false);
            //    previousMenuPage = null;
            //    currentMenuPage = null;
            //    menuClosed = true;
            //}

            if (currentMenuPage == null)
            {
                Debug.Log("back button on closed menu");
                previousMenuPage = null;
                currentMenuPage = mainMenuCanvas;
                currentMenuPage.SetActive(true);
                menuClosed = false;
            }
            else if (currentMenuPage == mainMenuCanvas)
            {
                Debug.Log("back button on mainMenu second if");
                currentMenuPage.SetActive(false);
                previousMenuPage = null;
                currentMenuPage = null;
                menuClosed = true;
            }
            else
            {
                OpenPreviousPage();
            }
           


        }
    }

    void OpenPreviousPage()
    {
        currentMenuPage.SetActive(false);
        
        //i don't think this is the way to do it... idk fuck i need to look up a way to handle the back buttons.
        //I think there should be a defined state machine it moves through. ah well.

        if (currentMenuPage == mainMenuCanvas)
        {
            Debug.Log("Closing Main Menu from button");
            currentMenuPage = null;
            menuClosed = true;

        }
        else
        {
            previousMenuPage.SetActive(true);
            currentMenuPage = previousMenuPage;

        }
        previousMenuPage = null;

    }

    //fuck how should I do this?
    void OpenPage(GameObject pageToOpen)
    {

        previousMenuPage = currentMenuPage;
        previousMenuPage.SetActive(false);

        currentMenuPage = pageToOpen;
        currentMenuPage.SetActive(true);

    }
    

    private void OnDestroy()
    {
        MLInput.Stop();
        MLInput.OnControllerButtonDown -= OnButtonDown;

    }
}
