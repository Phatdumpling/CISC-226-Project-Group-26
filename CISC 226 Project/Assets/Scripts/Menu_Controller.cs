using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{

    [SerializeField] private GameObject thisObj;
    [SerializeField] private GameObject IsParent;
    
    
    // Start is called before the first frame update
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Past self saving");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How to play");
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
