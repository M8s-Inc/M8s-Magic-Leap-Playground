using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeap.Core.StarterKit;
using TMPro;

public class PlaceableDevice : MonoBehaviour
{
    public int triggerSubscribeNum = 0;

    public LayerMask m_defaultLayer;

    public M8MLController myController;

    [Header("Device Popup Refs")]
    public GameObject deviceOptionsPopup;
    public bool optionsPopupActive = false;
    public GameObject popupText;
    public string test;

    public bool followButtonActive = true;
    public GameObject followButton;
    public GameObject unfollowButton;

    public UIManager uiManager;

    private void Awake()
    {

        #if PLATFORM_LUMIN
        //MLInput.OnTriggerDown += HandleOnTriggerDown;
        #endif
    }

    void OnDestroy()
    {
    #if PLATFORM_LUMIN
        //MLInput.OnTriggerDown -= HandleOnTriggerDown;
    #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        popupText.GetComponent<TextMeshProUGUI>().text = this.gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void ToggleFollowButton()
    {
        if(followButtonActive)
        {
            followButton.SetActive(false);
            unfollowButton.SetActive(true);
        }
        else
        {
            followButton.SetActive(true);
            unfollowButton.SetActive(false);
        }

        followButtonActive = !followButtonActive;
    }

    public void ToggleOptionsPopup()
    {
        if (!optionsPopupActive)
        {
            OpenOptionsPopup();
        }
        else
        {
            CloseOptionsPopup();
        }
    }

    public void OpenOptionsPopup()
    {
        optionsPopupActive = true;
        deviceOptionsPopup.SetActive(true);
        //uiManager.otherMenuOpen = true;
        myController.UnsubscribeTriggerDown();
        SubscribeTriggerDown();
    }

    public void CloseOptionsPopup()
    {
        optionsPopupActive = false;
        deviceOptionsPopup.SetActive(false);
        //uiManager.otherMenuOpen = false;
        myController.SubscribeTriggerDown();
        UnsubscribeTriggerDown();
    }

    /// <summary>
    /// Handles the event for triggerPushed down.
    /// </summary>
    /// <param name="controller_id">The id of the controller.</param>
    /// <param name="value">The value of the triggerPushed button.</param>
    private void HandleOnTriggerDown(byte controllerId, float value)
    {
        Debug.Log("Inside trigger press in " + this.gameObject.name);
        Debug.Log(myController.controller.TriggerValue);

        #if PLATFORM_LUMIN
        if (myController.controller != null && myController.controller.Id == controllerId)
        {
            MLInput.Controller.FeedbackIntensity intensity = (MLInput.Controller.FeedbackIntensity)((int)(value * 2.0f));
            myController.controller.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.Buzz, intensity);
        }
        #endif

        if (myController.controller.TriggerValue > 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(myController.m_rayCastOrigin.transform.position, myController.m_rayCastOrigin.transform.forward, out hit))
            {
                //I think my script was being called multiple times.
                if (hit.transform.IsChildOf(deviceOptionsPopup.transform))
                {
                    //this may be redundant, but I'm doing it to ensure it works when switching between multiple menus. I think the should close other menus but I'll figure that out later.
                    myController.selectedGameObject = this.gameObject;

                    if (hit.transform.gameObject.name == "Move_Button")
                    {
                        //do I need this? or should this already be true before 
                        Debug.Log("Move button pressed inside " + this.gameObject.name);
                        myController.devicePlacementActive = true;
                        CloseOptionsPopup();

                        //snap attach point to device.
                        //myController.attachPoint.transform.position = this.transform.position;

                        //Snap attachpoint to where the movebutton is pressed - so the raycast matches the attachpoint.
                        myController.attachPoint.transform.position = hit.transform.position;
                        this.transform.position = myController.attachPoint.transform.position;

                    }
                    else if (hit.transform.gameObject.name == "Follow_Button")
                    {
                        Debug.Log("follow button pressed inside " + this.gameObject.name);
                        this.gameObject.GetComponent<MagicLeap.PlaceFromCamera>().enabled = true;
                        CloseOptionsPopup();
                        ToggleFollowButton();
                    }
                    else if (hit.transform.gameObject.name == "Unfollow_Button")
                    {
                        Debug.Log("unfollow button pressed inside " + this.gameObject.name);
                        this.gameObject.GetComponent<MagicLeap.PlaceFromCamera>().enabled = false;
                        CloseOptionsPopup();
                        ToggleFollowButton();
                    }
                    //do i even need this? I think i'll make do with the controller.
                    else if (hit.transform.gameObject.name == "Configure_Button")
                    {
                        Debug.Log("Device Configure Menu to come");
                        CloseOptionsPopup();
                    }
                    else if (hit.transform.gameObject.name == "Delete_Button")
                    {
                        Debug.Log("delete button pressed inside " + this.gameObject.name);
                        CloseOptionsPopup();
                        this.gameObject.SetActive(false);
                    }
                }
                
            }
        }
        
    }

    public void SubscribeTriggerDown()
    {
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        triggerSubscribeNum++;
    }

    public void UnsubscribeTriggerDown()
    {
        MLInput.OnTriggerDown -= HandleOnTriggerDown;
        triggerSubscribeNum--;
    }

}
