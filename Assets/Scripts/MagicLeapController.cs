using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeap.Core.StarterKit;

using UnityEngine.UI;
//Not the best naming convension, but this is where I'm building the logic to connect various Magic Leap Components to my interactable devices. 
//There is a seperate script for the actual controller, so I'll rename this script down the line.

public enum CurrentLeftHandPose
{
    None,
    C,
    Fist,
    L,
    Ok,
    OpenHand,
    Pinch,
    Finger,
    Thumb
}

public enum CurrentRightHandPose
{
    None,
    C,
    Fist,
    L,
    Ok,
    OpenHand,
    Pinch,
    Finger,
    Thumb
}

//should i dock this all in there? will that effect anything else? can only one namespace be used at a time?
//namespace MagicLeap
public class MagicLeapController : MonoBehaviour
{
    //HandTracking Variables
    private MLHandTracking.HandKeyPose[] m_gestures; // Holds the different hand poses we will look for.
    public CurrentLeftHandPose m_currentLeftPose;
    public CurrentRightHandPose m_currentRightPose;

    //Is there a reason I should get the gameobject instead of just the colliders from the start?
    public GameObject m_leftHandCenter;
    private Collider m_leftHandCollider;
    public bool m_leftHandGripping = false; 

    public GameObject m_rightHandCenter;
    private Collider m_rightHandCollider;
    public bool m_rightHandGripping = false;


    //posedirection - I want to be able to get the direction of a pose, like a thumb, for additional input.

    //Pretty sure i dont need this.
    //[Tooltip("The reference to the class to handle results from.")]
    public Ray raycast;

    //Raycast stuff.
    [SerializeField, Tooltip("Raycast Visualizer.")]
    private MagicLeap.MLRaycastVisualizer _raycastVisualizer = null;

    [SerializeField, Tooltip("Raycast from headpose.")]
    private MLRaycastBehavior _raycastHead = null;

    //remame to _raycastConfidence
    private float _confidence = 0.0f;

    public LayerMask layerMask;

    //Focued Object variables
    [SerializeField, Tooltip("Current Device Being Focused.")]
    public GameObject currentFocusedDevice = null;

    // Start is called before the first frame update
    void Start()
    {
        MLHandTracking.Start(); // Start the hand tracking.
        m_gestures = new MLHandTracking.HandKeyPose[7]; //Assign the gestures we will look for.
        m_gestures[0] = MLHandTracking.HandKeyPose.Fist;
        m_gestures[1] = MLHandTracking.HandKeyPose.Thumb;
        m_gestures[2] = MLHandTracking.HandKeyPose.Finger;
        m_gestures[3] = MLHandTracking.HandKeyPose.OpenHand;
        m_gestures[4] = MLHandTracking.HandKeyPose.Ok;
        m_gestures[5] = MLHandTracking.HandKeyPose.NoPose;
        m_gestures[6] = MLHandTracking.HandKeyPose.NoHand;

        MLHandTracking.KeyPoseManager.EnableKeyPoses(m_gestures, true, false); // Enable the hand poses.

        EnableRaycast(_raycastHead);

        //Get Hand Center's Colliders.
        m_leftHandCollider = m_leftHandCenter.GetComponent<Collider>();

        m_rightHandCollider = m_rightHandCenter.GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo = new RaycastHit();
        if(Physics.Raycast(ray, out hitInfo, 100, layerMask))
        {
            Debug.Log("Gaze Raycast hit: " + hitInfo.transform.gameObject.name);
            FocusDevice(hitInfo.transform.gameObject);
        }
        else
        {
            if(currentFocusedDevice)
            {
                ClearFocus();
            }
        }

        // lets see what this does. Ok no dice i cant access the actual ray it uses easily, so I'm just gonna do this from scratch.
        //if (Physics.Raycast(_raycastHead.transform.position, out hitInfo, 100, layerMask))
        //{
        //    //StartCoroutine(SmoothMoveToHand(hitInfo.collider.transform));
        //}

        //Hand Tracking - Setting Hand Poses.
        if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.Thumb))
        {
            Debug.Log("Left hand thumb pose detected - on");
            m_currentLeftPose = CurrentLeftHandPose.Thumb;
        }
        else if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.Fist))
        {
            Debug.Log("Left hand fist pose detected - off");
            m_currentLeftPose = CurrentLeftHandPose.Fist;
        }
        else if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.Finger))
        {
            Debug.Log("Left hand finger pose detected - Mode 1");
            m_currentLeftPose = CurrentLeftHandPose.Finger;
        }
        else if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.OpenHand))
        {
            Debug.Log("Left hand Open Hand pose detected - Mode 2");
            m_currentLeftPose = CurrentLeftHandPose.OpenHand;
        }
        else if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.Ok))
        {
            Debug.Log("Left hand OK pose detected - Mode 3");
            m_currentLeftPose = CurrentLeftHandPose.Ok;
        }
        else if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.NoPose))
        {
            //turning off cuse its spamming
            //Debug.Log("Left hand no pose detected");
            m_currentLeftPose = CurrentLeftHandPose.None;
        }
        else if (GetGesture(MLHandTracking.Left, MLHandTracking.HandKeyPose.NoHand))
        {
            //turning off cuse its spamming
            //Debug.Log("Left hand no hand detected");
            m_currentLeftPose = CurrentLeftHandPose.None;
        }
        //If Right hand
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.Thumb))
        {
            Debug.Log("Right hand thumb pose detected - on");
            m_currentRightPose = CurrentRightHandPose.Thumb;
        }
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.Fist))
        {
            Debug.Log("Right hand fist pose detected - off");
            m_currentRightPose = CurrentRightHandPose.Fist;
        }
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.Finger))
        {
            Debug.Log("Right hand finger pose detected - Mode 1");
            m_currentRightPose = CurrentRightHandPose.Finger;
        }
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.OpenHand))
        {
            Debug.Log("Right hand Open Hand pose detected - Mode 2");
            m_currentRightPose = CurrentRightHandPose.OpenHand;
        }
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.Ok))
        {
            Debug.Log("Right hand OK pose detected - Mode 3");
            m_currentRightPose = CurrentRightHandPose.Ok;
        }
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.NoPose))
        {
            //turning off cuse its spamming
            //Debug.Log("Right hand no pose detected");
            m_currentRightPose = CurrentRightHandPose.None;
        }
        else if (GetGesture(MLHandTracking.Right, MLHandTracking.HandKeyPose.NoHand))
        {
            //turning off cuse its spamming
            //Debug.Log("Right hand no hand detected");
            m_currentRightPose = CurrentRightHandPose.None;
        }


        /*
        //Turning On Hand Colliders (Messy)
        if (m_currentLeftPose == CurrentLeftHandPose.Fist)
        {
            m_leftHandGripping = true;
            m_leftHandCollider.enabled = true;

        }
        else
        {
            m_leftHandGripping = false;
            m_leftHandCollider.enabled = false;

        }



        if (m_currentRightPose == CurrentRightHandPose.Fist)
        {
            m_rightHandGripping = true;
            m_rightHandCollider.enabled = true;

        }
        else
        {
            m_rightHandGripping = false;
            m_rightHandCollider.enabled = false;

        }
        */

    }


    private void FocusDevice(GameObject device)
    {

        currentFocusedDevice = device;

        //Is there any logic I need to put here to go through and only run if they have this component?
        //should I make the GazeFocus behavior a seperate script that each device also has on its gameObject and just references it?
        currentFocusedDevice.GetComponent<LightDeviceContoller>().GazeFocusedOnDevice();

        Debug.Log("Device Focused: " + currentFocusedDevice.name);

    }

    private void ClearFocus()
    {
        //should clear focus off the last focused device...
        currentFocusedDevice.GetComponent<LightDeviceContoller>().ClearGazeOnDevice();
        currentFocusedDevice = null;

        Debug.Log("Focus Cleared");

    }
    bool GetGesture(MLHandTracking.Hand hand, MLHandTracking.HandKeyPose type)
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

    /// <summary>
    /// Enables raycast behavior and raycast visualizer
    /// </summary>
    private void EnableRaycast(MLRaycastBehavior raycast)
    {
        raycast.gameObject.SetActive(true);
        _raycastVisualizer.raycast = raycast;

        #if PLATFORM_LUMIN
        _raycastVisualizer.raycast.OnRaycastResult += _raycastVisualizer.OnRaycastHit;
        _raycastVisualizer.raycast.OnRaycastResult += OnRaycastHit;
        #endif
    }

    /// <summary>
    /// Disables raycast behavior and raycast visualizer
    /// </summary>
    private void DisableRaycast(MLRaycastBehavior raycast)
    {
        if (raycast != null)
        {
            raycast.gameObject.SetActive(false);

            #if PLATFORM_LUMIN
            raycast.OnRaycastResult -= _raycastVisualizer.OnRaycastHit;
            raycast.OnRaycastResult -= OnRaycastHit;
            #endif
        }
    }

    public void OnRaycastHit(MLRaycast.ResultState state, MLRaycastBehavior.Mode mode, Ray ray, RaycastHit result, float confidence)
    {
        _confidence = confidence;
    }
}
