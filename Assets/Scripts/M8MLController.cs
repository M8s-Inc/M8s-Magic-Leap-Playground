using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeap.Core.StarterKit;


//This is my Controller Script. I want to use as little of Magic Leap's code as possible, but for the sake of controller interactions I'll use it so i dont have to configure controller settings. 
public class M8MLController : MonoBehaviour
{

    public LayerMask m_defaultLayer;
    public LayerMask m_UILayer;

    //private Ray ControllerRayCast = new Ray();
    //private RaycastHit ControllerRayCastHit = new RaycastHit();

    public bool devicePlacementActive = true;

    public GameObject m_objectPrefab;
    public Transform m_placedObject;
    public Transform m_rayCastOrigin;

    [Space, SerializeField, Tooltip("MLControllerConnectionHandlerBehavior reference.")]
    private MLControllerConnectionHandlerBehavior _controllerConnectionHandler = null;

    private Ray ControllerRayCast;
    private RaycastHit ControllerRayCastHit;

    //Placement indicator & variables
    public Transform placementRef;
    public float smoothnessFactor = 0.2f;
    public Vector3 posToMove;

    private void Awake()
    {
        if (_controllerConnectionHandler == null)
        {
            Debug.LogError("Error: RaycastExample._controllerConnectionHandler not set, disabling script.");
            enabled = false;
            return;
        }

#if PLATFORM_LUMIN
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnTriggerDown += HandleOnTriggerDown;

#endif
    }

    void OnDestroy()
    {
#if PLATFORM_LUMIN
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnTriggerDown -= HandleOnTriggerDown;
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        ControllerRayCast = new Ray(m_rayCastOrigin.position, m_rayCastOrigin.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //How costly is it do this every frame? I need to look back into compute calculations and big O notation.
        ControllerRayCast = new Ray(m_rayCastOrigin.position, m_rayCastOrigin.forward);
        ControllerRayCastHit = new RaycastHit();

        //if device placement mode is active...
        if (devicePlacementActive)
        {
            
            if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_defaultLayer))
            {
                Debug.Log("inside placement ref setting");
                placementRef.gameObject.SetActive(true);

                Vector3 desiredPosition = ControllerRayCastHit.point;
                Vector3 vecToDesired = desiredPosition - placementRef.position;

                vecToDesired *= smoothnessFactor;
                placementRef.position += vecToDesired;

                posToMove = new Vector3(ControllerRayCastHit.point.x, ControllerRayCastHit.point.y, ControllerRayCastHit.point.z);
                //StartCoroutine(TeleportWithFade(posToMove));

            }
        }
        else //UI interactions enabled?
        {
            if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_UILayer))
            {

            }
        }

    }

    /// <summary>
    /// Handles the event for button down and cycles the raycast mode.
    /// </summary>
    /// <param name="controllerId">The id of the controller.</param>
    /// <param name="button">The button that is being pressed.</param>
    private void OnButtonDown(byte controllerId, MLInput.Controller.Button button)
    {
        if (_controllerConnectionHandler.IsControllerValid(controllerId) && button == MLInput.Controller.Button.Bumper)
        {
            //_raycastMode = (RaycastMode)((int)(_raycastMode + 1) % _modeCount);
            //UpdateRaycastMode();
            Debug.Log("Bumper Press");
            if (devicePlacementActive)
            {
                PlaceDevice(posToMove);
            }
        }
    }

    /*
    public void PlaceDevice()
    {
        Ray ControllerRayCast = new Ray(m_rayCastOrigin.position, m_rayCastOrigin.forward);
        RaycastHit ControllerRayCastHit = new RaycastHit();
        

        //if (Physics.Raycast(ControllerRayCast, 100.0f, m_defaultLayer))
        if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_defaultLayer))
        {
            Debug.Log("inside Raycast ");

            if (!m_placedObject)
            {
                //returns the transofrm 
                m_placedObject = Instantiate(m_objectPrefab, ControllerRayCastHit.point, Quaternion.identity).transform;
                Debug.Log("placed object was null");

            }
            else
            {
                m_placedObject.position = ControllerRayCastHit.point;
                Debug.Log("placed object wasnt null");

            }
        }
    }
    */
    public void PlaceDevice(Vector3 placementPosition)
    {


        //if (Physics.Raycast(ControllerRayCast, 100.0f, m_defaultLayer))
        if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_defaultLayer))
        {
            Debug.Log("inside Raycast ");

            if (!m_placedObject)
            {
                //returns the transofrm 
                m_placedObject = Instantiate(m_objectPrefab, ControllerRayCastHit.point, Quaternion.identity).transform;
                Debug.Log("placed object was null");

            }
            else
            {
                m_placedObject.position = ControllerRayCastHit.point;
                Debug.Log("placed object wasnt null");

            }
        }
    }

    /// <summary>
    /// Handles the event for trigger down.
    /// </summary>
    /// <param name="controller_id">The id of the controller.</param>
    /// <param name="value">The value of the trigger button.</param>
    private void HandleOnTriggerDown(byte controllerId, float value)
    {
        MLInput.Controller controller = _controllerConnectionHandler.ConnectedController;
        Debug.Log("inside trigger pressed ");

#if PLATFORM_LUMIN
        if (controller != null && controller.Id == controllerId)
        {
            MLInput.Controller.FeedbackIntensity intensity = (MLInput.Controller.FeedbackIntensity)((int)(value * 2.0f));
            controller.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.Buzz, intensity);
        }
#endif
    }
}
