using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;
public class animation_collisions : MonoBehaviour
{
    [SerializeField]
    private string _colliderScript;

    [SerializeField] 
    private UnityEvent _collisionEntered;

    [SerializeField] 
    private UnityEvent _collisionExit;

    
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTileMap;
    [SerializeField] 
    private Tilemap collision_Interactable;

    private Vector2 previous;
    
    private Player_Movement_Tile_by_Tile controls;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("interactables") || col.gameObject.CompareTag("Player"))
        {
            print("entered");
            _collisionEntered?.Invoke();
        }
        
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("interactables"))
        {
            print("entered");
            _collisionEntered?.Invoke();
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
            print("entered");
            _collisionEntered?.Invoke();   
        }
    }
    
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.GetComponent(_colliderScript))
        {
            print("exit");
            _collisionExit?.Invoke();
        }
    }
    */
}
