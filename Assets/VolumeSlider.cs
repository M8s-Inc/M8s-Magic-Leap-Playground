using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class VolumeSlider : MonoBehaviour
{

    public Text currentVolume;
    public Text maxVolume;

    public Slider volume_Slider;

    public Slider virtual_Slider;

    public bool isMuted = false;

    public bool isDragging = false;

    //For buttons. I need mute toggle, volume up and volume down.
    public Image muteIcon;
    public Image unmuteIcon;

    //lel shiet how do i do the formatting from seconds to 1:56 ex... 
    //

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentVolume.text = virtual_Slider.value.ToString();
        
        //was remaining time.
        maxVolume.text = (virtual_Slider.maxValue - virtual_Slider.value).ToString();
        
        if (isMuted)
        {
            muteIcon.enabled = false;
            unmuteIcon.enabled = true;
        }
        else
        {
            muteIcon.enabled = true;
            unmuteIcon.enabled = false;
        }
    }

    
    public void UpdateRealSlider()
    {
        volume_Slider.value = virtual_Slider.value;
    }

    public void UpdateVirtualSlider()
    {
        virtual_Slider.value = volume_Slider.value;
    }

    public void SliderDragStart()
    {
        isDragging = true;
        isMuted = false;
        Debug.Log("Slider Is being dragged" + volume_Slider.value.ToString() + "   Virtual" + virtual_Slider.value.ToString());

        //update real slider to where virtual slider is... right?
        UpdateRealSlider();
    }

    public void SliderDragEnd()
    {

        UpdateVirtualSlider();
        isDragging = false;
        //isPlaying = true;
        Debug.Log("Slider released - Real - " + volume_Slider.value.ToString() + "   Virtual" + virtual_Slider.value.ToString());
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
    }
}
