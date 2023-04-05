using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Canvas theCanvas = GetComponentInParent<Canvas>();
        theCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}
