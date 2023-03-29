using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer audioMixer;
    public Slider theslider;
    public void Start()
    {
        audioMixer.GetFloat("Master", out float volume);
        //this.value = volume;
    }
}
