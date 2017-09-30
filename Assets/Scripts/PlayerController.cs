using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 5f;
	public float speedBreathing = 3f;
	public float speedWalking = 5f;
	public float jumpForce = 3f;
	public float jumpBuffer = 0.1f;
	public bool wantsToJump;
	public bool justLeftPlatform;
	public bool isJumping;
	public float maxVelocity;
	private float movLerp;
	public float airControl;
	public float gravityFactor;

	private Rigidbody2D rb;
	public bool isGrounded;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			StartCoroutine ("JumpInputBuffering");
		}
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
			if (wantsToJump) 
			{
				rb.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
				isJumping = true;
			} 

			movLerp = 1f;
		} 

		else 
		{
			movLerp = airControl;

			if (wantsToJump && justLeftPlatform && !isJumping) 
			{
				rb.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
				isJumping = true;
			}

			if (Input.GetButtonUp ("Jump"))
			{
				rb.gravityScale = rb.gravityScale * gravityFactor;
			}
		}

		//Max speed

		rb.velocity = Vector2.ClampMagnitude (rb.velocity, maxVelocity);
	}

	IEnumerator JumpInputBuffering ()
	{
		wantsToJump = true;
		yield return new WaitForSeconds (jumpBuffer);
		wantsToJump = false;
	}

	IEnumerator JumpGraceTimer ()
	{
		justLeftPlatform = true; 
		yield return new WaitForSeconds (jumpBuffer);
		justLeftPlatform = false;
	}

	//isGrounded = true;
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Floor") 
		{
			isGrounded = true;
			isJumping = false;
			rb.gravityScale = 1;
		}
	}		

	//isGrounded = false;
	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Floor") 
		{
			isGrounded = false;
			StartCoroutine ("JumpGraceTimer");
		}
	} 	
}