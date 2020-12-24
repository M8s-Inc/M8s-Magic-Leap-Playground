using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.MagicLeap;
using MagicLeap.Core;
using MagicLeap.Core.StarterKit;


//This is my Controller Script. I want to use as little of Magic Leap's code as possible, but for the sake of controller interactions I'll use it so i dont have to configure controller settings. 
public class M8MLController : MonoBehaviour
{
    public int triggerSubscribeNum = 0;
    public int buttonSubscribeNum = 0;

    public LayerMask m_defaultLayer;
    public LayerMask m_UILayer;
    public LayerMask m_deviceLayer;

    [Space, SerializeField, Tooltip("MLControllerConnectionHandlerBehavior reference.")]
    private MLControllerConnectionHandlerBehavior _controllerConnectionHandler = null;
    public MLInput.Controller controller;


    [Header("Object Placement Refs")]
    public GameObject m_deviceToPlace;
    public Transform m_placedObject;

    [Header("Object Manipulation Refs")]
    public bool devicePlacementActive = false;

    public GameObject selectedGameObject;
    public GameObject attachPoint;
    public Transform attachPointDefault;

    bool trigger;
    //This didnt work.
    public string nameOfLayer = "Ignore Raycast";
    LayerMask layer;
    public int layerToIgnore = 2;
    int skipLayer;


    [Header("Raycast Curve Refs")]
    public Transform m_rayCastOrigin;
    public bool rayCastIndicatorOn = false;
    private Ray ControllerRayCast;
    private RaycastHit ControllerRayCastHit;


    //Line Renderer Stuff
    private LineRenderer beamLine;
    public Color beamStartColor;
    public Color beamEndColor;

    public int pointCount = 50;
    public float bezierHeight = 1.0f;

    public float bezierMinHeight = 5.0f;
    public float bezierMaxHeight = 3.0f;
    public float maxLineDistance = 10.0f;

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

        beamLine = GetComponent<LineRenderer>();

        beamLine.enabled = false;


        #if PLATFORM_LUMIN
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        triggerSubscribeNum++;
        buttonSubscribeNum++;
#endif

    }

    void OnDestroy()
    {
        #if PLATFORM_LUMIN
        MLInput.OnControllerButtonDown -= OnButtonDown;
        MLInput.OnTriggerDown -= HandleOnTriggerDown;

        triggerSubscribeNum--;
        buttonSubscribeNum--;
        #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        //this isn't playing nice. idk why this won't work but the next line does.
        //controller = _controllerConnectionHandler.ConnectedController;

        controller = MLInput.GetController(MLInput.Hand.Left);

        Debug.Log("Controller reference inside M8MLController " + controller.ToString());
        if (controller == null)
        {
            Debug.Log("Controller reference is null");
        }

        //Line Renderer Stuff
        //ControllerRayCast = new Ray(m_rayCastOrigin.position, m_rayCastOrigin.forward);
        beamLine = GetComponent<LineRenderer>();
        beamLine.startColor = beamStartColor;
        beamLine.endColor = beamEndColor;

        //Object Manipulation
        layer = ~(1 << LayerMask.NameToLayer(nameOfLayer));

        //Save Default attachPoint transform for resetting.
        //attachPointDefault.position = attachPoint.transform.position;
        //attachPointDefault.rotation = attachPoint.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        //How costly is it do this every frame? I need to look back into compute calculations and big O notation.
        ControllerRayCast = new Ray(m_rayCastOrigin.position, m_rayCastOrigin.forward);
        ControllerRayCastHit = new RaycastHit();

        if(rayCastIndicatorOn)
        {
            if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 20f))
            {
                Vector3 desiredPosition = ControllerRayCastHit.point;
                Vector3 vecToDesired = desiredPosition - placementRef.position;

                vecToDesired *= smoothnessFactor;
                placementRef.position += vecToDesired;

                beamLine.enabled = true;

                Vector3 startPoint = m_rayCastOrigin.transform.position;
                Vector3 endPoint = placementRef.position;

                Vector3 midPoint = ((endPoint - startPoint) / 2f) + startPoint;

                //Diferent methods of doing the line renderer. For now going to make it just a straight line.

                beamLine.SetPosition(0, startPoint);

                //beamLine.SetPosition(1, endPoint);

                if (devicePlacementActive)
                {
                    beamLine.SetPosition(1, attachPoint.transform.position);
                }
                else
                {
                    beamLine.SetPosition(1, endPoint);
                }


                //Curved
                //midPoint += Vector3.up * bezierHeight;
                //midPoint += Vector3.up * Mathf.Lerp(bezierMinHeight, bezierMaxHeight, Mathf.Clamp(Vector3.Distance(startPoint, endPoint),0,1));

                //Curved 2
                //midPoint += Vector3.up * Mathf.Lerp(bezierMinHeight, bezierMaxHeight, Mathf.Clamp(Vector3.Distance(startPoint, endPoint) / maxLineDistance, 0, 1));

                //for (int i = 0; i < pointCount; i++)
                //{
                //    Vector3 lerp1 = Vector3.Lerp(startPoint, midPoint, i / (float)pointCount);
                //    Vector3 lerp2 = Vector3.Lerp(midPoint, endPoint, i / (float)pointCount);

                //    Vector3 curvePosition = (Vector3.Lerp(lerp1, lerp2, i / (float)pointCount));

                //    beamLine.SetPosition(i, curvePosition);
                //}

                if (ControllerRayCastHit.collider.tag == "Ground")
                {
                    beamLine.startColor = Color.blue;
                    beamLine.endColor = Color.cyan;
                }
                else if (ControllerRayCastHit.collider.tag == "Device")
                {
                    beamLine.startColor = Color.green;
                    beamLine.endColor = Color.yellow;
                }
                else
                {
                    beamLine.startColor = beamStartColor;
                    beamLine.endColor = beamEndColor;
                }
            }
            else
            {
                //turning off cuse its spamming
                //Debug.Log("M8ML Controller Line Renderer Off");

                //beamLine.enabled = false;
                Debug.Log("Controller Raycast not hitting?");
                beamLine.SetPosition(0, transform.position);

                if (devicePlacementActive)
                {
                    beamLine.SetPosition(1, attachPoint.transform.position);
                }
                else
                {
                    beamLine.SetPosition(1, transform.forward * 3);
                }
            }
        }
        

        
        ////if device placement mode is active...
        //if (devicePlacementActive)
        //{
        //    if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_defaultLayer))
        //    {

        //        Debug.Log("inside placement ref setting");
        //        placementRef.gameObject.SetActive(true);

        //        Vector3 desiredPosition = ControllerRayCastHit.point;
        //        Vector3 vecToDesired = desiredPosition - placementRef.position;

        //        vecToDesired *= smoothnessFactor;
        //        placementRef.position += vecToDesired;

        //        posToMove = new Vector3(ControllerRayCastHit.point.x, ControllerRayCastHit.point.y, ControllerRayCastHit.point.z);
        //        //StartCoroutine(TeleportWithFade(posToMove));

        //    }
        //}

        if(devicePlacementActive )
        {
            ManipulateDevice();
        }


    }



    public void PlaceDevice(Vector3 placementPosition)
    {

        //if (Physics.Raycast(ControllerRayCast, 100.0f, m_defaultLayer))
        if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_defaultLayer))
        {
            Debug.Log("inside Raycast ");

            if (!m_placedObject)
            {
                //returns the transofrm 
                m_placedObject = Instantiate(m_deviceToPlace, ControllerRayCastHit.point, Quaternion.identity).transform;
                Debug.Log("placed object was null");
            }
            else
            {
                m_placedObject.position = ControllerRayCastHit.point;
                Debug.Log("Object Placed, Clearing m_deviceToPlace");
                m_deviceToPlace = null;
            }
        }
    }

    void ManipulateDevice()
    {
        //Rotate to orientation of controller.
        //selectedGameObject.transform.rotation = gameObject.transform.rotation;
        selectedGameObject.transform.rotation = Quaternion.Slerp(selectedGameObject.transform.rotation, attachPoint.transform.rotation, 0.1f);
        selectedGameObject.transform.position = attachPoint.transform.position;

        if (controller.Touch1Active)
        {
            float x = controller.Touch1PosAndForce.x;
            float y = controller.Touch1PosAndForce.y;
            float force = controller.Touch1PosAndForce.z;

            if (force > 0)
            {
                if (x > 0.5 || x < -0.5)
                {
                    selectedGameObject.transform.localScale += selectedGameObject.transform.localScale * x * Time.deltaTime;
                }

                if (y > 0.3 || y < -0.3)
                {
                    attachPoint.transform.position = Vector3.MoveTowards(attachPoint.transform.position, gameObject.transform.position, -y * Time.deltaTime);
                }
                Debug.Log(" Inside ManipulateDevice : X " + x + "  y " + y + "  force " + force);
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
                //actually dont think I want this to be called here anyway...
                //PlaceDevice(posToMove);
                //devicePlacementActive = false;
            }
            else //if not actively placing device
            {
                Debug.Log("MyController inside else Bumper Press");

                //cast a ray, if it hits a device, open that object's popup menu
                if (Physics.Raycast(ControllerRayCast, out ControllerRayCastHit, 100.0f, m_deviceLayer))
                {
                    //close any menu that may be open before selecting new device.
                    //if(selectedGameObject!=null)
                    //{
                    //    selectedGameObject.GetComponent<PlaceableDevice>().CloseOptionsPopup();
                    //}

                    selectedGameObject = ControllerRayCastHit.transform.gameObject;
                    selectedGameObject.GetComponent<PlaceableDevice>().ToggleOptionsPopup();

                }
            }
        }

        if (selectedGameObject != null && _controllerConnectionHandler.IsControllerValid(controllerId) && button == MLInput.Controller.Button.HomeTap)
        {
            if (selectedGameObject.GetComponent<PlaceableDevice>().optionsPopupActive)
            {
                selectedGameObject.GetComponent<PlaceableDevice>().CloseOptionsPopup();
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
        Debug.Log("inside trigger pressed in " + this.gameObject.name);

        #if PLATFORM_LUMIN
        if (controller != null && controller.Id == controllerId)
        {
            MLInput.Controller.FeedbackIntensity intensity = (MLInput.Controller.FeedbackIntensity)((int)(value * 2.0f));
            controller.StartFeedbackPatternVibe(MLInput.Controller.FeedbackPatternVibe.Buzz, intensity);
        }
        #endif

        if (controller.TriggerValue > 0.8f && devicePlacementActive)
        {
            //actually dont think I want this to be called here anyway...
            //PlaceDevice(posToMove);
            Debug.Log("inside triggerdown device placement");
            devicePlacementActive = false;

            //Update the PCF Binding.
            selectedGameObject.GetComponent<MagicLeap.PersistentDevice>().DeviceTransformBinding.Update();
            //DeviceTransformBinding.Update();

            //this isn't working - now it does.
            attachPoint.transform.position = attachPointDefault.position;
            attachPoint.transform.rotation = attachPointDefault.rotation;


        }

        /*
        //For ManipulateDevice (I need to create a popup menu first).
        if (controller.TriggerValue > 0.8f)
        {
            Debug.Log("trigger down inside manipulate object: " + controller.TriggerValue);
            if (trigger == true)
            {
                RaycastHit hit;

                //Layer didn't work for me here.
                //if(Physics.Raycast(controller.Position, transform.forward, out hit, layer))

                //why wont this shit work. do i need a fucking max distance?
                //if (Physics.Raycast(controller.Position, transform.forward, out hit, Mathf.Infinity, skipLayer))
                if (Physics.Raycast(controller.Position, transform.forward, out hit, Mathf.Infinity, layer))
                {
                    if (hit.transform.gameObject.tag == "Interactable")
                    {
                        Debug.Log("Interactable hit: " + controller.TriggerValue);
                        selectedGameObject = hit.transform.gameObject;
                        selectedGameObject.GetComponent<Rigidbody>().useGravity = false;
                        attachPoint.transform.position = hit.transform.position;
                    }
                }
                trigger = false;
            }
        }
        if (controller.TriggerValue < 0.2f)
        {
            //Debug.Log("trigger down inside manipulate object: " + controller.TriggerValue);

            trigger = true;
            if (selectedGameObject != null)
            {
                selectedGameObject.GetComponent<Rigidbody>().useGravity = true;
                selectedGameObject = null;
            }
        }
        */
    }

    public void SubscribeTriggerDown()
    {
        Debug.Log("Inside SubscribeTriggerDown");
        MLInput.OnTriggerDown += HandleOnTriggerDown;
        triggerSubscribeNum++;
    }

    public void UnsubscribeTriggerDown()
    {
        Debug.Log("Inside UnsubscribeTriggerDown");
        MLInput.OnTriggerDown -= HandleOnTriggerDown;
        triggerSubscribeNum--;
    }
}
