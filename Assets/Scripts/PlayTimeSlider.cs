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

    public bool isPlaying = true;

    public bool isDragging = false;

    public Image PlayIcon;
    public Image PauseIcon;

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

        if(isPlaying && !isDragging)
        {
            virtual_Slider.value += Time.deltaTime;
        }

        if(isPlaying)
        {
            PlayIcon.enabled = false;
            PauseIcon.enabled = true;
        }
        else
        {
            PlayIcon.enabled = true;
            PauseIcon.enabled = false;
        }
    }

    public void UpdateRealSlider()
    {
        playTime_Slider.value = virtual_Slider.value; 
    }

    public void UpdateVirtualSlider()
    {
        virtual_Slider.value = playTime_Slider.value;
    }

    public void SliderDragStart()
    {
        isDragging = true;
        isPlaying = false;
        Debug.Log("Slider Is being dragged");
        UpdateRealSlider();
    }

    public void SliderDragEnd()
    {
        UpdateVirtualSlider();
        isDragging = false;
        //isPlaying = true;
        Debug.Log("Slider released - Real - " + playTime_Slider.value.ToString() + "   Virtual" + virtual_Slider.value.ToString());
    }

    public void TogglePlay()
    {
        isPlaying = !isPlaying;
    }
}
