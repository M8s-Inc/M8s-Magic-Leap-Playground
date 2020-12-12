using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void ClickAction();
    //static lets you reference it in other classes.
    public static event ClickAction OnClicked;


    void OnGUI()
    {
        //creates button on screen.
        if (GUI.Button(new Rect(Screen.width / 2 - 50, 5, 100, 30), "Click"))
        {
            Debug.Log("Button clicked?");
            //if there are functions subscribed to the event
            if (OnClicked != null)
                OnClicked();
        
        }
    }
}
