using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{

    [SerializeField] private GameObject thisObj;
    [SerializeField] private GameObject HowToPlayObj;
    [SerializeField] private Canvas HowToPlayCanvas;
    
    
    // Start is called before the first frame update
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 2 past self 1");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How to play");
        /*
        HowToPlayCanvas.transform.localScale = HowToPlayCanvas.transform.localScale / 2;
        HowToPlayCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        */
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("Start Screen");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }
    
    
    /* DO NOT UNCOMMENT
    public void HowToPlayPopUp()
    {
        Instantiate(thisObj);
        thisObj.transform.parent = IsParent.transform;
        thisObj.transform.localScale =- new Vector3(-0.5f, 0.5f, 0.5f);
    }
    
    public void HowToPlayPopDown()
    {
        
    }
    */
    
    
}
