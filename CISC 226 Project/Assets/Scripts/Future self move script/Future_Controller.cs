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
    [SerializeField] 
    private Tilemap past_is_short;

    private Vector2 previous;
    
    private Future_movement controls;

    public LayerMask whatStopsMovement;

    public Transform past_self_position;
    public GameObject pastSelfObject;
    public Transform death_sight1;
    public Transform death_sight2;
    public Transform death_sight3;
    
    
    public Sprite Up;
    public Sprite Down;
    public Sprite Left;
    public Sprite Right;



    public int counter = 0;
    public int extra_actions = 20;

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
                
                AudioManager.Instance.PlaySFX("Move");
                
                
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

        if (PauseMenu.isPaused == true)
        {
            return false;
        }

        return true;
    }

    private void PastPlayerRotate(GameObject theObject, String Direction)
    {

        Vector3 temp = Vector3.zero;

        if (Direction == "Right")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Right;

            temp = Vector3.right;

        } else if (Direction == "Left")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Left;

            temp = Vector3.left;

        } else if (Direction == "Up")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Up;

            temp = Vector3.up;

        } else if (Direction == "Down")
        {
            theObject.GetComponent<SpriteRenderer>().sprite = Down;

            temp = Vector3.down;
            
                    
        }
        
        Sightmove(theObject, temp); // Moving the sight
        
        
        // This section Accounts for sight bumping into walls
        Vector3Int DS1 = groundTilemap.WorldToCell(death_sight1.position);
        Vector3Int DS2 = groundTilemap.WorldToCell(death_sight2.position);
        Vector3Int DS3 = groundTilemap.WorldToCell(death_sight3.position);
        
        if (collisionTileMap.HasTile(DS1)||past_is_short.HasTile(DS1))
        {
            death_sight1.position = past_self_position.position;
            death_sight2.position = past_self_position.position;
            death_sight3.position = past_self_position.position;
            
        } else if ((collisionTileMap.HasTile(DS2)||past_is_short.HasTile(DS2)))
        {
            death_sight2.position = death_sight1.position;
            death_sight3.position = death_sight1.position;
            
        } else if ((collisionTileMap.HasTile(DS3)||past_is_short.HasTile(DS3)))
        {
            death_sight3.position = death_sight2.position;
            
        }
        
        
    }

    private void Sightmove(GameObject theObject, Vector3 DirectionVec)
    {
        death_sight1.position = theObject.transform.position + DirectionVec;
        death_sight2.position = theObject.transform.position + DirectionVec * 2;
        death_sight3.position = theObject.transform.position + DirectionVec * 3;
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