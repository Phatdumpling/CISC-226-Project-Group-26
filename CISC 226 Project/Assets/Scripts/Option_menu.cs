using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Option_menu : MonoBehaviour
{

    public AudioMixer audioMixer;
    
    public Slider volumeSlider;
    
    
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    
    void Start()
    {
        audioMixer.GetFloat("Volume", out float volume);
        volumeSlider.value = volume;
        Debug.Log(volumeSlider.value);
        Debug.Log(volume);
    }
    
}
