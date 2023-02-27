using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;
using Vector3 = System.Numerics.Vector3;

public class Collisondetectorball : MonoBehaviour
{
    private int counter = 0;
    [SerializeField]
    private string _colliderScript;
    public Transform player;

    [SerializeField] 
    private UnityEvent _collisionEntered;
    

    [SerializeField] 
    private UnityEvent _collisionExit;
    
    public LayerMask thePlayer;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
            print("entered");
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
            //print("entered");
            
            if (player.GetChild(0).position.x + 0.05 > transform.position.x &&
                player.GetChild(0).position.x - 0.05 < transform.position.x)
            {
                print(player.GetChild(0).position.x + 0.3);
                print(player.GetChild(0).position.x - 0.3);
                print("invalid");
                
            }
            else
            {
                print("tansform position x" + transform.position.x);
                print("tansform position y" + transform.position.y);
                print("child position x" + player.GetChild(0).position.x);
                print("child position y" + player.GetChild(0).position.y);
                
                if (transform.position.x > player.GetChild(0).position.x)
                {
                    transform.position += UnityEngine.Vector3.left;
                }else {
                    transform.position += UnityEngine.Vector3.right;
                }
            }
            if (player.GetChild(0).position.y + 0.3 > transform.position.y &&
                player.GetChild(0).position.y - 0.3 < transform.position.y)
            {
                print(player.GetChild(0).position.y + 0.3);
                print(player.GetChild(0).position.y - 0.3);
                print("invalid");
                
            }
            else
            {
                print("tansform position x" + transform.position.x);
                print("tansform position y" + transform.position.y);
                print("child position x" + player.GetChild(0).position.x);
                print("child position y" + player.GetChild(0).position.y);
                
                if (transform.position.y < player.GetChild(0).position.y)
                {
                    transform.position += UnityEngine.Vector3.up;
                }else {
                    transform.position += UnityEngine.Vector3.down;
                }
            }
            
            
            
            //transform.position += UnityEngine.Vector3.up;
            //transform.position += UnityEngine.Vector3.down;
            //print(transform.position);
            counter = 1;
        }
    }
}
