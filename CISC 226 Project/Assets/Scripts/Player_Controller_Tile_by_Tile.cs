using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;

public class Player_Controller_Tile_by_Tile : MonoBehaviour
{
    public float moveSpeed = 1f;

    public Transform movePoint;
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTileMap;
    [SerializeField] 
    private Tilemap collision_Interactable;

    private Vector2 previous;
    
    private Player_Movement_Tile_by_Tile controls;
    

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
        movePoint.parent = null;
        controls.Main.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
        {
            
            previous = transform.position;
            transform.position += (Vector3)direction;
            movePoint.position += Vector3.MoveTowards(movePoint.position, transform.position, moveSpeed*Time.deltaTime);
        }
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        //collisionTileMap.HasTile(gridPosition)||
        //|| collision_Interactable.HasTile(gridPosition)
        if (!groundTilemap.HasTile(gridPosition) || collisionTileMap.HasTile(gridPosition))
        {
            print("false");
            return false;
        }
        print("true");
        return true;
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Colliding"))
        {
            transform.position = previous;
            print("collision occured");
        }
        
    }
}