using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin_adjustable : MonoBehaviour
{
    public RectTransform thisObj;
    public int SpinSpeed;
    private void FixedUpdate()
    {
        thisObj.Rotate(0, 0, -1*SpinSpeed);
    }
}
