using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotchLever : MonoBehaviour
{
    public float notchSpeed;
    public Transform start;
    public Transform end;

    private Transform closest;

    public List<Transform> notches = new List<Transform>();

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            closest = null;
            Vector3 heading = (end.position - start.position);
            float magnitudeOfHeading = heading.magnitude;
            heading.Normalize();

            Vector3 startToHand = other.transform.position - start.position;
            float dotProduct = Vector3.Dot(startToHand, heading);
            dotProduct = Mathf.Clamp(dotProduct, 0f, magnitudeOfHeading);
            Vector3 spot = start.position + heading * dotProduct;

            transform.position = spot;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Controller")// && Input.GetKey(KeyCode.G))
        {
            closest = start;
            foreach (var notch in notches)
            {
                if (Vector3.Distance(transform.position, notch.position) < Vector3.Distance(transform.position, closest.position))
                {
                    closest = notch;
                }
            }
            //transform.position = closest.position;
        }
    }
    private void Update()
    {
        if(closest)
        {
            transform.position = Vector3.MoveTowards(transform.position, closest.position, notchSpeed*Time.deltaTime);
        }
    }
}
