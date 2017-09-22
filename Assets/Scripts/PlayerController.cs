using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float jumpForce = 3f;
	public float maxVelocity;
	private float movLerp;
	public float airControl;
	public float gravityFactor;

	private Rigidbody2D rb;
	private bool isGrounded;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		//Movement

		float xinput = Input.GetAxisRaw ("Horizontal");	

		if (isGrounded || xinput != 0)
			rb.velocity = Vector2.Lerp (rb.velocity, new Vector2 (xinput * speed, rb.velocity.y), movLerp);

		//Jump

		if (isGrounded) 
		{
			if (Input.GetButtonDown ("Jump")) 
			{
				rb.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
			}

			movLerp = 1f;
		} 

		else 
		{
			movLerp = airControl;

			if (Input.GetButtonUp ("Jump"))
			{
				rb.gravityScale = rb.gravityScale * gravityFactor;
			}
		}

		//Max speed

		rb.velocity = Vector2.ClampMagnitude (rb.velocity, maxVelocity);
	}

	//isGrounded = true;
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Floor") 
		{
			isGrounded = true;
			rb.gravityScale = 1;
		}
	}		

	//isGrounded = false;
	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Floor") 
		{
			isGrounded = false;
		}
	} 	
}