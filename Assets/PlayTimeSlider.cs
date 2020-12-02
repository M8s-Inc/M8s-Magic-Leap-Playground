using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class PlayTimeSlider : MonoBehaviour
{

    public Text playTime;
    public Text remainingTime;

    public Slider playTime_Slider;

    public Slider virtual_Slider;


    //lel shiet how do i do the formatting from seconds to 1:56 ex... 
    //

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playTime.text = virtual_Slider.value.ToString();
        remainingTime.text = (virtual_Slider.maxValue - virtual_Slider.value).ToString();

        virtual_Slider.value += Time.deltaTime;

        //cock sucking fuck Idk how to use this function lol. 
        //playTime_Slider.OnDrag(playTime_Slider.handleRect);
    }

    public void UpdateRealSlider()
    {
        playTime_Slider.value = virtual_Slider.value; 


    }
}
