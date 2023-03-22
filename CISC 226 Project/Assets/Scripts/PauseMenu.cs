using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public AudioSource theMusic;
    
    //public AudioMixer audioMixer;
    //private float MixerVol = 0;

    public GameObject PauseMenuUI;
    public Canvas theCanvas;

    // Update is called once per frame

    private void Start()
    {
        PauseMenuUI.SetActive(false);
        theCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        theMusic.UnPause();
        
        //audioMixer.SetFloat("Volume", MixerVol);
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        theMusic.Pause();


        /*
        audioMixer.GetFloat("Volume", out float value);
        MixerVol = value;
        audioMixer.SetFloat("Volume", -80);
        */

    }
}
