using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprovedLever : MonoBehaviour
{
    public Transform start;
    public Transform end;

    //Current value of slider.
    public float range;
    //public float localRange;

    public float currentValue;

    private void Start()
    {
        range = end.position.x - start.position.x;
        //
        Debug.Log("Slider Range = " + range);

        //localRange = end.localPosition.x - start.localPosition.x;
        //Debug.Log("Slider local Range = " + localRange);

        //Debug.Log("Startpoint position " + start.position.x + "  local: = " + start.localPosition.x);
        //Debug.Log("Endpoint position " + end.position.x + "  local: = " + end.localPosition.x);


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

            //To calculate the value % the lever is pushed. 
            Vector3 currentVector = (spot - start.position);
            float currentVectorMagnitude = currentVector.magnitude;

            currentValue = (currentVectorMagnitude / range) * 100.0f;
            //Debug.Log("currentVectorMagnitude = " + currentVectorMagnitude);
            Debug.Log("XR Lever currentValue = " + currentValue);

        }
    }

    private void Update()
    {
        //Debug.Log("Slider Range = " + range);
    }
}
