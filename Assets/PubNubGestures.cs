using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;
using PubNubAPI;

public class PubNubGestures : MonoBehaviour
{
    public float sendTimeController;
    public static PubNub pubnub;


    //private  MLHandTracking.HandKeyPose[] gestures; // Holds the different hand poses we will look for.
    private MLHandTracking.HandKeyPose[] gestures; // Holds the different hand poses we will look for.


    void Awake()
    {

        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-270dafe4-6c23-47e4-b9eb-62d9590a9846";
        pnConfiguration.SubscribeKey = "sub-c-2e822568-1d76-11eb-8a07-eaf684f78515";
        pnConfiguration.Secure = true;
        pubnub = new PubNub(pnConfiguration);
        MLHandTracking.Start(); // Start the hand tracking.
        gestures = new MLHandTracking.HandKeyPose[3]; //Assign the gestures we will look for.
        gestures[0] = MLHandTracking.HandKeyPose.Fist;
        gestures[1] =  MLHandTracking.HandKeyPose.Thumb;
        gestures[2] =  MLHandTracking.HandKeyPose.Finger;
        MLHandTracking.KeyPoseManager.EnableKeyPoses(gestures, true, false); // Enable the hand poses.
    }

    void OnDestroy()
    {
        MLHandTracking.Stop();
    }
    void Update()
    {
        if (sendTimeController <= Time.deltaTime)
        { // Restrict how often messages can be sent.
            if (GetGesture(MLHandTracking.Left,  MLHandTracking.HandKeyPose.Thumb) || GetGesture(MLHandTracking.Right,  MLHandTracking.HandKeyPose.Thumb))
            {
                pubnub.Publish()
                    .Channel("control")
                    .Message("on")
                    .Async((result, status) => {
                        if (!status.Error)
                        {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        }
                        else
                        {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                sendTimeController = 0.1f; // Stop multiple messages from being sent.
            }
            else if (GetGesture(MLHandTracking.Left,  MLHandTracking.HandKeyPose.Fist) || GetGesture(MLHandTracking.Right,  MLHandTracking.HandKeyPose.Fist))
            {
                pubnub.Publish()
                    .Channel("control")
                    .Message("off")
                    .Async((result, status) => {
                        if (!status.Error)
                        {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        }
                        else
                        {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                sendTimeController = 0.1f; // Stop multiple messages from being sent.
            }
            else if (GetGesture(MLHandTracking.Left,  MLHandTracking.HandKeyPose.Finger))
            {
                pubnub.Publish()
                    .Channel("control")
                    .Message("changel")
                    .Async((result, status) => {
                        if (!status.Error)
                        {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        }
                        else
                        {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                sendTimeController = 0.9f; // Stop multiple messages from being sent.
            }
            else if (GetGesture(MLHandTracking.Right,  MLHandTracking.HandKeyPose.Finger))
            {
                pubnub.Publish()
                    .Channel("control")
                    .Message("changer")
                    .Async((result, status) => {
                        if (!status.Error)
                        {
                            Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                        }
                        else
                        {
                            Debug.Log(status.Error);
                            Debug.Log(status.ErrorData.Info);
                        }
                    });
                sendTimeController = 0.9f; // Stop multiple messages from being sent.
            }
        }
        else
        {
            sendTimeController -= Time.deltaTime; // Update the timer.
        }
    }
    bool GetGesture(MLHandTracking.Hand hand,  MLHandTracking.HandKeyPose type)
    {
        if (hand != null)
        {
            if (hand.KeyPose == type)
            {
                if (hand.HandKeyPoseConfidence > 0.98f)
                {
                    return true;
                }
            }
        }
        return false;
    }
}