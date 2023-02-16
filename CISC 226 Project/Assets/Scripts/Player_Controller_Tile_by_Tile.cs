using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Tilemaps;

public class Player_Controller_Tile_by_Tile : MonoBehaviour
{
    
    [SerializeField]
    private Tilemap groundTilemap;
    [SerializeField]
    private Tilemap collisionTileMap;
    [SerializeField] private Tilemap collision_Interactable;
    
    
    
    private Player_Movement_Tile_by_Tile controls;
    
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;
    Vector2 movement;
    

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
            //transform.position += (Vector3)direction;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
        }
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
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
