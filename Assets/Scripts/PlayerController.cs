using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    float xinput;
    float yinput;
	public float speed;
	public float speedBreathing = 3f;
	public float speedWalking = 5f;
    public float speedJumping;
	public float jumpForce = 3f;
	public float jumpBuffer = 0.1f;
	public bool wantsToJump;
	public bool justLeftPlatform;
	public bool isJumping;
	public float maxVelocity;
    //public float airControl;
    public float normalGravity;
	public float downGravity;

	private Rigidbody2D rb;
    public PlayerStates state;
    Coroutine jumpGraceCor;

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

		xinput = Input.GetAxisRaw("Horizontal");
        yinput = Input.GetAxisRaw("Vertical");

        if (state == PlayerStates.OnLadder)
            MoveY();
        else
            MoveX();

        //Jump

        JumpAndAirbourne();
	}

    void MoveY()
    {
        rb.velocity = new Vector2(0f, yinput * speed);
    }

    void MoveX()
    {
        if (state != PlayerStates.Airbourne || xinput != 0)
        {
            rb.velocity = new Vector2(xinput * speed, rb.velocity.y);
        }
    }

    void JumpAndAirbourne()
    {
        if (state == PlayerStates.Grounded)
        {
            if (wantsToJump)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        if (state == PlayerStates.OnLadder)
        {
            if (wantsToJump)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;

                state = PlayerStates.Airbourne;
                rb.gravityScale = normalGravity;
            }
        }

        if (state == PlayerStates.Airbourne)
        {
            speed = speedJumping;

            if (wantsToJump && justLeftPlatform && !isJumping)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }

            if (Input.GetButtonUp("Jump") || rb.velocity.y < 0)
            {
                rb.gravityScale = downGravity;
            }

            //Max speed

            rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxVelocity);
        }
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

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Floor") 
		{
            state = PlayerStates.Grounded;
			isJumping = false;
			rb.gravityScale = normalGravity;
            speed = speedWalking;
		}
	}		

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Ladder" && yinput > 0 && state != PlayerStates.OnLadder)
        {
            state = PlayerStates.OnLadder;
            rb.gravityScale = 0;
            xinput = 0;
        }
    }

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Floor") 
		{
            if (state != PlayerStates.OnLadder)
                state = PlayerStates.Airbourne;

            if (jumpGraceCor != null)
                StopCoroutine(jumpGraceCor);
            jumpGraceCor = StartCoroutine(JumpGraceTimer());
        }

        if (col.tag == "Ladder")
        {
            if (state == PlayerStates.OnLadder)
            {
                state = PlayerStates.Airbourne;
                rb.gravityScale = normalGravity;

                if (jumpGraceCor != null)
                    StopCoroutine(jumpGraceCor);
                jumpGraceCor = StartCoroutine(JumpGraceTimer());
            }
        }
	} 	
}