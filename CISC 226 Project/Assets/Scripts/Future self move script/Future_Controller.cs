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
    public GameObject pastSelfObject;
    
    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;



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
            else // This else statement is when it is valid to move
            {
                print(positions.Count);
                if (counter < positions.Count)
                {
                    past_self_position.position = positions[counter];
                    PastPlayerRotate(pastSelfObject, facing_dir[counter]);
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
                
                
                // Future self rotate
                
                FutureRotate(prev);
                
                
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

    private void PastPlayerRotate(GameObject theObject, String Direction)
    {
        if (Direction == "Right")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Right;

        } else if (Direction == "Left")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Left;
                    
        } else if (Direction == "Up")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Up;
                    
        } else if (Direction == "Down")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Down;
                    
        }
    }


    private void FutureRotate(Vector3 previous)
    {
        if (transform.position.x - previous.x > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Right;

        } else if (transform.position.x - previous.x < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Left;
                    
        } else if (transform.position.y - previous.y > 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Up;
                    
        } else if (transform.position.y - previous.y < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Down;
                    
        }
    }
    
}