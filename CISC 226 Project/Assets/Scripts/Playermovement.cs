using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    
	public float moveSpeed = 1f;
	
	public Rigidbody2D rb;
	
	Vector2 movement;

    // Update is called once per frame
    void Update()
    {
 
        movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
	//movement = new vector2()
    }

    void FixedUpdate()
	{
	rb.MovePosition(rb.position+movement*moveSpeed*Time.fixedDeltaTime);
	//transform.position = 
	print(rb.position);
	}

}
