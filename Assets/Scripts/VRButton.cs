using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButton : MonoBehaviour
{
    private Animator anim;
    //public CannonController cannon;

    private bool isPressed = false;

    private Vector3 collisionVector;

    public float collisionDirection;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Controller" && !isPressed)
        {
            collisionVector = other.transform.position - transform.position;
            Debug.Log(collisionVector);

            collisionDirection = Vector3.Dot(transform.up, collisionVector.normalized);
            Debug.Log(collisionDirection);

            if(collisionDirection > 0.7f)
            { 
                anim.SetTrigger("ButtonPressed");
                //cannon.FireCannon();
                Debug.Log(this.name + "Button pressed - collision was in exceptable range");
                isPressed = true;
            }

        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Controller")
        {
            isPressed = false;
            Debug.Log(this.name + "trigger exited");
        }
    }
}
