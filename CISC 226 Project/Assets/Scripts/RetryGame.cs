using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryGame : LastScene
{
    // Start is called before the first frame update
    public AudioSource theMusic;
    public void LoadGame()
    {
        //theMusic.UnPause();
        SceneManager.LoadScene(lastScene);
        
    }
}
