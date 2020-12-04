using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRButton : MonoBehaviour
{
    private Animator anim;

    public Transform start;
    public Transform end;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            Vector3 heading = (end.position - start.position);
            float magnitudeOfHeading = heading.magnitude;
            heading.Normalize();

            Vector3 startToHand = other.transform.position - start.position;
            float dotProduct = Vector3.Dot(startToHand, heading);
            dotProduct = Mathf.Clamp(dotProduct, 0f, magnitudeOfHeading);
            Vector3 spot = start.position + heading * dotProduct;

            transform.position = new Vector3(spot.x, spot.y, spot.z);

        }
    }

    private void OnTriggerExit(Collider other)
    {

        //-0.324 & -0.351 are my standard outputs. I guess these coordinates are in world space not local? 
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            if(transform.position.y > end.position.y + 0.005f)
            {
                Debug.Log(this.name + "world position inside press animation trigger. y pos:" + transform.position.y);

                anim.SetTrigger("ButtonPressed");
            }

            if (transform.localPosition.y < end.localPosition.y + 0.005f)
            {
                Debug.Log(this.name + "local position inside press animation trigger. y pos:" + transform.position.y);

                anim.SetTrigger("ButtonPressed");
            }

            Debug.Log(this.name + "XR Button Trigger Exity pos:" + transform.position.y + " & " + end.position.y);
            Debug.Log(this.name + "XR Button Trigger Exity local pos:" + transform.localPosition.y + " & " + end.localPosition.y);


        }
    }
}
