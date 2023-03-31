using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class PauseAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    
    public Slider MasterSlider;
    
    public Slider MusicSlider;
    
    public Slider SFXSlider;
    void Start()
    {
        audioMixer.GetFloat("Volume", out float MasterVolume);
        MasterSlider.value = MasterVolume;
        
        audioMixer.GetFloat("MusicExpose", out float MusicVolume);
        MusicSlider.value = MusicVolume;
        
        audioMixer.GetFloat("SFXExpose", out float SFXVolume);
        SFXSlider.value = SFXVolume;
    }
    
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicExpose", volume);
    }
    
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXExpose", volume);
    }
    
}
