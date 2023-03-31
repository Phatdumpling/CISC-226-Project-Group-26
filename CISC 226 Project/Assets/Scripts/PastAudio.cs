using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("Positive");
    }
}
