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

    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;

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

                if (transform.position.x - prev.x > 0)
                {
                    facing_dir.Add("Right");
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Right;

                } else if (transform.position.x - prev.x < 0)
                {
                    facing_dir.Add("Left");
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Left;
                    
                } else if (transform.position.y - prev.y > 0)
                {
                    facing_dir.Add("Up");
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
                    
                } else if (transform.position.y - prev.y < 0)
                {
                    facing_dir.Add("Down");
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
                    
                }

                Console.WriteLine(positions.ToString());
                Console.WriteLine(facing_dir.ToString());
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