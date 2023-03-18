using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Controller : MonoBehaviour
{
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
}
