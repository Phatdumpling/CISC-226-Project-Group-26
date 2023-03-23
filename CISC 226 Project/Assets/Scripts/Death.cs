﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask whatdeath;
    public AudioSource theMusic;

    public Canvas GameoverCanvas;
    public GameObject GameOverObj;
    
    public static Death Instance;
    void Start()
    {
        //GameoverCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
        //GameOverObj.SetActive(false);
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 0.2f, whatdeath))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        theMusic.Pause();
        //GameOverObj.SetActive(true);
        SceneManager.LoadScene("End Screen");

    }
    public void ReloadGame()
    {
        theMusic.UnPause();
        SceneManager.LoadScene("Future self saving");
        
    }
}
