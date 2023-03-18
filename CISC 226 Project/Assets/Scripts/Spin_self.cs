using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spin_self : MonoBehaviour
{
    public RectTransform thisObj;

    private float Rx;
    private float Ry;
    private float Rz;

    private float RSxMin;
    private float RSyMin;
    private float RSzMin;
    
    private float RSxMax;
    private float RSyMax;
    private float RSzMax;

    private void FixedUpdate()
    {
        Rotateframe();
    }

    private void Start()
    {

        Rx = RotateDecide();
        Ry = RotateDecide();
        Rz = RotateDecide();

        RSxMin = RotateSpeedDecideMin();
        RSyMin = RotateSpeedDecideMin();
        RSzMin = RotateSpeedDecideMin();

        RSxMax = RotateSpeedDecideMax();
        RSyMax = RotateSpeedDecideMax();
        RSzMax = RotateSpeedDecideMax();
    }

    private float RotateDecide()
    {
        if (Random.Range(0, 10) > 5)
        {
            return 1;
        }
        return -1;
    }

    private float RotateSpeedDecideMax()
    {
        return Random.Range(0, 15);
    }
    
    private float RotateSpeedDecideMin()
    {
        return Random.Range(0, -7);
    }

    private void Rotateframe()
    {
        thisObj.Rotate(Random.Range(RSxMin*Rx, RSxMax*Rx),Random.Range(RSyMin*Ry, RSyMax*Ry),Random.Range(RSzMin*Rz, RSzMax*Rz));
    }
}
