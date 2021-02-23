using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRButton : MonoBehaviour
{
    //Not using this currently. I'm animating programtically.
    private Animator anim;

    //add a collider to start position?
    public bool isToggleButton = false;
    public bool isToggled = false;
    Vector3 toggledPosition;

    public Transform start;
    public Transform end;

    public bool isPressed;

    public float delay = .5f;
    public float maxbuttonRiseDelta = 0.05f;

    float currenttime;

    float pressHeight;

    public string buttonType;
    public int buttonID;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;

        isPressed = false;
        currenttime = delay;

        //i want to trigger the event when the current buttonPosition < the pressHeight
        pressHeight = (end.localPosition.y - start.localPosition.y)/3;
        Debug.Log(this.name + "button PressHeight " + pressHeight);


        //I'm thoroughly confused. Why isn't this midpoint working?
        if(isToggleButton)
        {
            toggledPosition = (end.position + start.position) / 2;
            Debug.Log(this.gameObject.name + "Position for toggled position" + toggledPosition + " " + end.position + " " + start.position);
        }

    }

    private void Update()
    {
        if(!isPressed)
        {

            currenttime -= Time.deltaTime;

            if (currenttime < 0)
            {
                //move towards start position.
                Vector3 posToMove = Vector3.MoveTowards(transform.position, start.position, maxbuttonRiseDelta * Time.deltaTime);
                transform.position = posToMove;
            }

            if (isToggled)
            {
                if (transform.position == toggledPosition)
                {
                    isPressed = false;
                }
            }
            else
            {
                if (transform.position == start.position)
                {
                    isPressed = false;
                }
            }
            
        }
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            Vector3 collisionPoint;
            collisionPoint = other.ClosestPoint(end.position);
            //collisionPoint.position = other.transform.position;

            Vector3 heading = (end.position - start.position);
            float magnitudeOfHeading = heading.magnitude;
            heading.Normalize();

            //Vector3 startToHand = other.transform.position - start.position;
            Vector3 startToHand = collisionPoint - start.position;
            float dotProduct = Vector3.Dot(startToHand, heading);
            dotProduct = Mathf.Clamp(dotProduct, 0f, magnitudeOfHeading);
            Vector3 spot = start.position + heading * dotProduct;

            transform.position = new Vector3(spot.x, spot.y, spot.z);


            //experiment with calling these events multiple times. how will crestron parse the incoming SIO.
            if (transform.localPosition.y < end.localPosition.y + 0.005f)
            {
                Debug.Log(this.name + "local position inside press animation trigger. y pos:" + transform.position.y);
                //anim.enabled = true;
                //anim.SetTrigger("ButtonPressed");

                //Trigger Button Down Pressed/Released event. I need to figure out something for holding it down.

                if (buttonType == "TV")
                {
                    TVControls_EventSystem.current.XRButtonPressed(buttonID);
                }
                if (buttonType == "AppleTV")
                {
                    AppleTVControls_EventSystem.current.XRButtonPressed(buttonID);
                }

            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            //anim.
            anim.enabled = false;
            isPressed = true;


        }
    }

    private void OnTriggerExit(Collider other)
    {

        //-0.324 & -0.351 are my standard outputs. I guess these coordinates are in world space not local? 
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            //if(transform.position.y > end.position.y + 0.005f)
            //{
            //    Debug.Log(this.name + "world position inside press animation trigger. y pos:" + transform.position.y);

            //    anim.SetTrigger("ButtonPressed");
            //}

            if (transform.localPosition.y < end.localPosition.y + 0.005f)
            {
                Debug.Log(this.name + "local position inside press animation trigger. y pos:" + transform.position.y);
                //Who don't I need this now?
                //anim.enabled = true;
                //anim.SetTrigger("ButtonPressed");

                //Trigger Button Down Pressed/Released event. I need to figure out something for holding it down.
                if(buttonType == "TV")
                {
                    TVControls_EventSystem.current.XRButtonPressed(buttonID);
                }
                if (buttonType == "AppleTV")
                {
                    AppleTVControls_EventSystem.current.XRButtonPressed(buttonID);
                }

                if(isToggleButton)
                {
                    isToggled = !isToggled;
                    Debug.Log(this.name + " button toggle pressed : " + isToggled);

                }

            }

           // Debug.Log(this.name + "XR Button Trigger Exity pos:" + transform.position.y + " & " + end.position.y);
            //Debug.Log(this.name + "XR Button Trigger Exity local pos:" + transform.localPosition.y + " & " + end.localPosition.y);

            isPressed = false;
            currenttime = delay;

            //lets test this. going to halve the time so that it only rises halfway?
            //im dumb. thats not how i did it at all.
            //if(isToggled)
            //{
            //    currenttime /= 2;
            //}
        }
    }
}
