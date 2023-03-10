using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;
public class Collisondetector : MonoBehaviour
{
    private int counter = 0;
    private int start_working = 0;
    [SerializeField]
    private string _colliderScript;

    [SerializeField] 
    private UnityEvent _collisionEntered;
    

    [SerializeField] 
    private UnityEvent _collisionExit;
    
    public LayerMask thePlayer;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
            //print("entered");
          //  _collisionEntered?.Invoke();
        }
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
           // print("exit");
           // _collisionExit?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        
        if (Physics2D.OverlapCircle(transform.position, 0.2f, thePlayer))
        {
            print("trigger2");
            _collisionEntered?.Invoke();
            counter = 1;
            start_working ++;
        }
        else if(counter >= 1&&start_working>=50)
        {
            print("trigger1");
            _collisionExit?.Invoke();
            counter = 0;
        }
        
    }
}
