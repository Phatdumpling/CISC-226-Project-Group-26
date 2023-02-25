using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;
public class Collisondetectorball : MonoBehaviour
{
    private int counter = 0;
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
            print("exit");
           // _collisionExit?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        
        if (Physics2D.OverlapCircle(transform.position, 0.2f, thePlayer))
        {
            print("entered");
            do
            {
                //transform.position += ;
            } while (Physics2D.OverlapCircle(transform.position, 0.2f, thePlayer));
             
            counter = 1;
        }
    }
}
