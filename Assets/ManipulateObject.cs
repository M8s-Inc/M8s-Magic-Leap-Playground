using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ManipulateObject : MonoBehaviour
{
    private MLInput.Controller controller;

    private GameObject selectedGameObject;
    public GameObject attachPoint;
    public GameObject ControllerObject;

    bool trigger;

    //This didnt work.
    public string nameOfLayer = "Ignore Raycast";
    LayerMask layer;
    public int layerToIgnore = 2;
    int skipLayer;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);

        skipLayer = ~((1 << layerToIgnore));

        //this method didn't work
        layer = ~(1 << LayerMask.NameToLayer(nameOfLayer));

    }

    void UpdateTriggerInfo()
    {
        if(controller.TriggerValue > 0.8f)
        {
            Debug.Log("trigger down inside manipulate object: " + controller.TriggerValue);
            if (trigger == true)
            {
                RaycastHit hit;

                //Layer didn't work for me here.
                //if(Physics.Raycast(controller.Position, transform.forward, out hit, layer))

                //why wont this shit work. do i need a fucking max distance?
                //if (Physics.Raycast(controller.Position, transform.forward, out hit, Mathf.Infinity, skipLayer))
                if(Physics.Raycast(controller.Position, transform.forward, out hit, Mathf.Infinity, layer))
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
            Debug.Log("trigger down inside manipulate object: " + controller.TriggerValue);

            trigger = true;
            if (selectedGameObject != null)
            {
                selectedGameObject.GetComponent<Rigidbody>().useGravity = true;
                selectedGameObject = null;
            }
        }
    }

    void UpdateTouchPad()
    {
        if(controller.Touch1Active)
        {
            float x = controller.Touch1PosAndForce.x;
            float y = controller.Touch1PosAndForce.y;
            float force = controller.Touch1PosAndForce.z;

            if(force > 0)
            {
                if(x > 0.5 || x < -0.5)
                {
                    selectedGameObject.transform.localScale += selectedGameObject.transform.localScale * x * Time.deltaTime;
                }

                if (y > 0.3 || y < -0.3)
                {
                    attachPoint.transform.position = Vector3.MoveTowards(attachPoint.transform.position, gameObject.transform.position, -y * Time.deltaTime);
                }
                Debug.Log(" Inside UpdateTouchPad : X " + x + "  y " + y + "  force " + force);
            }
        }
    }

    private void OnDestroy()
    {
        MLInput.Stop();
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = controller.Position;
        transform.rotation = controller.Orientation;

        if(selectedGameObject)
        {
            //can I do set parent instead?
            selectedGameObject.transform.position = attachPoint.transform.position;
            selectedGameObject.transform.rotation = gameObject.transform.rotation;
        }

        UpdateTriggerInfo();
        UpdateTouchPad();
    }
}
