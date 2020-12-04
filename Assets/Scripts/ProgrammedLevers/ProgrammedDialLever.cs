using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgrammedDialLever : MonoBehaviour
{
    public Transform start;
    public Transform end;
    public Transform pivot;

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

            pivot.LookAt(spot);

        }
    }
}
