using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinBounceScreen : MonoBehaviour
{
    public RectTransform thisObj;
    public int SpinSpeed;
    
    public float speed = 50.0f;
    public RectTransform transform;
    public Rect canvasRect;

    public Vector2 move_dir = new Vector2(0,0);
    private Vector2 lastpos;

    private void Start()
    {
        //transform = GetComponent<RectTransform>();
        canvasRect = GetComponentInParent<Canvas>().pixelRect;
        //canvasRect.x = canvasRect.width/2;
        //canvasRect.y = canvasRect.height/2;

        move_dir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
    }
    
    
    private void FixedUpdate()
    {
        thisObj.Rotate(0, 0, -1*SpinSpeed);



        lastpos = transform.anchoredPosition;
        
        transform.anchoredPosition += move_dir*speed;

        
        

        // Position clamping
        
        Vector2 clamped = transform.anchoredPosition;
        clamped.x = Mathf.Clamp(clamped.x, transform.rect.width / 2, canvasRect.width - transform.rect.width / 2);
        clamped.y = Mathf.Clamp(clamped.y, transform.rect.height / 2, canvasRect.height - transform.rect.height / 2);
        transform.anchoredPosition = clamped;

        if ((lastpos.x - transform.anchoredPosition.x) == 0)
        {
            move_dir.x *= -1;
        }
            
        if ((lastpos.y - transform.anchoredPosition.y) == 0)
        {
            move_dir.y *= -1;
        }

        if (Random.Range(0, 100) == 1)
        {
            move_dir = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)).normalized;
        }
        
    }
    
    /*
    private void Bounce()
    {
        if ((lastpos-transform.anchoredPosition).magnitude < 1)
        {
            if (lastpos.x < transform.anchoredPosition.x)
            {
                //left
                if (lastpos.y < transform.anchoredPosition.y)
                {
                    //down
                    move_dir = new Vector2(Random.Range(-100, -1), Random.Range(-100, -1)).normalized;
                    move_dir.y *= -1;
                }
                else
                {
                    //up
                    move_dir = new Vector2(Random.Range(-100, -1), Random.Range(1, 100)).normalized;
                }
                
                move_dir.x *= -1;
            }
            else
            {
                //right
                if (lastpos.y < transform.anchoredPosition.y)
                {
                    //down
                    move_dir = new Vector2(Random.Range(1, 100), Random.Range(-100, -1)).normalized;
                    move_dir.y *= -1;
                }
                else
                {
                    //up
                    move_dir = new Vector2(Random.Range(1, 100), Random.Range(1, 100)).normalized;
                }
            }

            bootlegcounter = 20;
        }
    }*/
}
