using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simple_Spin : MonoBehaviour
{
    
    public RectTransform thisObj;


    private void FixedUpdate()
    {
        thisObj.Rotate(0, 0, -2);
    }
}
