using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class Future_Controller : Position_save
{
    
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTileMap;
    [SerializeField] 
    private Tilemap collision_Interactable;

    private Vector2 previous;
    
    private Future_movement controls;

    public LayerMask whatStopsMovement;

    public Transform past_self_position;

    public int counter = 0;
    public int extra_actions = 5;

    private void Awake()
    {
        controls = new Future_movement();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }


    // Start is called before the first frame update
    void Start()
    {
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            Vector3 prev = transform.position;
            transform.position += (Vector3)direction;
            
            if (Physics2D.OverlapCircle(transform.position, 0.2f, whatStopsMovement))
            {
                transform.position = prev;
            }
            else
            {
                print(positions.Count);
                if (counter < positions.Count)
                {
                    past_self_position.position = positions[counter];
                    counter++;
                }
                else
                {
                    extra_actions--;
                    if (extra_actions == 0)
                    {
                        SceneManager.LoadScene("End Screen");
                    }
                }
                
                
                //positions.RemoveAt(0);
            }
            
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        
        if (!groundTilemap.HasTile(gridPosition) || collisionTileMap.HasTile(gridPosition)||collision_Interactable.HasTile(gridPosition))
        {
            return false;
        }

        return true;
    }
}