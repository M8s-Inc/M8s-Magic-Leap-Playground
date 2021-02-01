using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;


public class LightDeviceContoller : MonoBehaviour
{
    //Magic Leap Controller
    public MagicLeapController m_magicLeapController;

    public bool m_focusOfGaze;

    [SerializeField, Tooltip("Last Left hand pose")]
    public CurrentLeftHandPose lastLeftHandPose;

    //Materials

    public MeshRenderer m_meshRenderer;

    [SerializeField, Tooltip("Default Material")]
    public Material m_defaultMaterial;

    public Material m_mat1;
    public Material m_mat2;
    public Material m_mat3;

    [SerializeField, Tooltip("Current Material")]
    public Material currentMaterial;

    //popup animator
    [SerializeField, Tooltip("UI & Device Tooltip popup")]
    public GameObject deviceUI;
    public Animator popupAnim;

    //private MLHandTracking.HandKeyPose[] gestures; // Holds the different hand poses we will look for.

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        m_focusOfGaze = false;
        m_meshRenderer = GetComponent<MeshRenderer>();
        //m_defaultMaterial = GetComponent<MeshRenderer>().GetComponent<Material>();
        //m_defaultMaterial2 = GetComponent<Material>();

        currentMaterial = m_defaultMaterial;

        if(!m_magicLeapController)
        {
            m_magicLeapController = Camera.main.GetComponent<MagicLeapController>();
        }



    }

    // Update is called once per frame
    void Update()
    {
        //Enable hand gesture inputs if object is being focused. Maybe I need to create an invisible bubble to expand the raycast-hitable area.
        if(m_focusOfGaze)
        {
            deviceUI.SetActive(true);
            popupAnim.SetTrigger("OpenPopup");

            if (lastLeftHandPose != CurrentLeftHandPose.OpenHand && m_magicLeapController.m_currentLeftPose == CurrentLeftHandPose.OpenHand)
            {
                Debug.Log("inside device if openhand");
                currentMaterial = m_defaultMaterial;
                m_meshRenderer.material = currentMaterial;
                lastLeftHandPose = CurrentLeftHandPose.OpenHand;

            }
            else if (lastLeftHandPose != CurrentLeftHandPose.Finger && m_magicLeapController.m_currentLeftPose == CurrentLeftHandPose.Finger)
            {
                Debug.Log("inside device if finger");
                currentMaterial = m_mat1;
                m_meshRenderer.material = currentMaterial;
                lastLeftHandPose = CurrentLeftHandPose.Finger;
            }
            else if (lastLeftHandPose != CurrentLeftHandPose.Fist && m_magicLeapController.m_currentLeftPose == CurrentLeftHandPose.Fist)
            {
                Debug.Log("inside device if fist");
                currentMaterial = m_mat2;
                m_meshRenderer.material = currentMaterial;
                lastLeftHandPose = CurrentLeftHandPose.OpenHand;

            }
            else if (lastLeftHandPose != CurrentLeftHandPose.Ok && m_magicLeapController.m_currentLeftPose == CurrentLeftHandPose.Ok)
            {
                Debug.Log("inside device if ok");
                currentMaterial = m_mat3;
                m_meshRenderer.material = currentMaterial;
                lastLeftHandPose = CurrentLeftHandPose.Ok;
            }
            //else if (lastLeftHandPose != CurrentLeftHandPose.None && m_magicLeapController.m_currentLeftPose == CurrentLeftHandPose.None)
            //{
            //    //this isn't necessary. it just ends up resetarting the current state.
            //    Debug.Log("inside device if none");
            //    currentMaterial = m_defaultMaterial;
            //    m_meshRenderer.material = currentMaterial;
            //    lastLeftHandPose = CurrentLeftHandPose.None;
            //}
            //else
            //{
            //    Debug.Log("inside device - else");
            //    //m_meshRenderer.material = currentMaterial;
            //    currentMaterial = m_defaultMaterial;
            //    m_meshRenderer.material = currentMaterial;
            //}
        }
        else
        {
            StartCoroutine(WaitToDisableDeviceUI());
            popupAnim.SetTrigger("ClosePopup");
        }

    }

    public void GazeFocusedOnDevice()
    {
        m_focusOfGaze = true;
    }

    public void ClearGazeOnDevice()
    {
        m_focusOfGaze = false;
    }

    IEnumerator WaitToDisableDeviceUI()
    {
        float currentTime = 0;

        while (currentTime < 3)
        {
            yield return null;

            if (m_focusOfGaze == true)
            {
                yield break;
            }
            currentTime += Time.deltaTime;
        }

        deviceUI.SetActive(false);

    }
}
