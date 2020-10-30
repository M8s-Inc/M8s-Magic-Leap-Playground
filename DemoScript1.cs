using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataClass
{
    public int myInt;
    public float myFloat;
}

public class DemoScript1 : MonoBehaviour
{

    //variables
    public Light myLight;
    public DataClass dataClass;
    public Color myColor;

    //can only be accessed through only this script.
    private Light myOtherLight;



    //functions

    //First Function called when a scene is started? when this gameObject is instantiated.
    void Awake()
    {

        Debug.Log(addTwo(9, 2));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame. Usually where code most things will go.
    void Update()
    {
        //Key capture options for lights.
        /*
        if (Input.GetKey("space"))
        {
            myLight.enabled = true;
        }
        else
        {
            myLight.enabled = false;
        }
        */

        /*
        if (Input.GetKeyDown("space"))
        {
            myLight.enabled = true;
        }
        if (Input.GetKeyUp("space"))
        {
            myLight.enabled = false;
        }
        */
        if (Input.GetKeyDown("space"))
        {
            MyLightToggle();
            myLight.color = new Color(Random.value, Random.value, Random.value, 1.0f);
            Debug.Log("Color is " + myColor);
        }

        if (Input.GetKeyDown("r"))
        {
            myLight.color = Color.red;
            Debug.Log("Color is " + myColor);
        }
        if (Input.GetKeyDown("b"))
        {
            myLight.color = Color.blue;
            Debug.Log("Color is " + myColor);
        }
        if (Input.GetKeyDown("g"))
        {
            myLight.color = Color.green;
            Debug.Log("Color is " + myColor);
        }
    }

    //Called when you want to play with physics. Space game example. Your render speed is based on how many things are going on. Particle systems, all the crap doing things. You don't need to waste that time doing complicated physics computations. 
    //Space battle.lots of shit going on, theres tons of processing going on, so even if the frame rate drops, you want to make sure physics don't start breaking down.
    void FixedUpdate()
    {
        
    }

    //LateUpdate is called at the end of the frame. so make sure all of the gameObjects update.
    //Good for cameras. we don't have much control over which object is called first. If you updated camera along with a character moving for example, and it bumps into something, the camera might jiggle. maybe that would be a fun way to test it?
    void LateUpdate()
    {
        
    }
    
    //classes

    void MyLightToggle()
    {
        myLight.enabled = !myLight.enabled;

    }

    int addTwo(int var1, int var2)
    {
        int returnValue = var1 + var2;
        return returnValue;
    }

}
