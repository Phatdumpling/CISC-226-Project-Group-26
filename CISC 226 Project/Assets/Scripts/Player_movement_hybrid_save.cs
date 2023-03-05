using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;

public class Player_movement_hybrid_save : Position_save
{
    
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTileMap;
    [SerializeField] 
    private Tilemap collision_Interactable;

    private Vector2 previous;
    
    private Player_Movement_Tile_by_Tile controls;

    public LayerMask whatStopsMovement;
    

    private void Awake()
    {
        controls = new Player_Movement_Tile_by_Tile();
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
                positions.Add(transform.position);
                Console.WriteLine("positions.ToString()");
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