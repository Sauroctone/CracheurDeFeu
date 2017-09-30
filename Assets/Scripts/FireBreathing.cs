using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour {

	public ParticleSystem fireBreath;
	private PlayerController player;
	private BottleManager bottles;
	private float rightStickX;
	private float rightStickY;
	private float angle;
	private float scaleX;
	private float fireRotationX;
	public GameObject playerVisuals;
	public GameObject fireRotator;

	void Start()
	{
		player = GetComponent<PlayerController> ();
		bottles = GetComponent<BottleManager> ();
		scaleX = playerVisuals.transform.localScale.x;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!fireBreath.isPlaying && Input.GetButtonDown ("BreatheFire") && bottles.bottleCount > 0) 
		{
			fireBreath.Play ();
			player.speed = player.speedBreathing;
			bottles.bottleCount -= 1;
		}

		if (!fireBreath.isEmitting)
			player.speed = player.speedWalking;

		rightStickX = Input.GetAxis("RS_Vertical");
		rightStickY = Input.GetAxis("RS_Horizontal");
		angle = Mathf.Atan2(rightStickX, rightStickY) * Mathf.Rad2Deg;

		if (rightStickX != 0 || rightStickY != 0) 
		{
			fireRotator.transform.localEulerAngles = new Vector3 (0, angle, 0);
		}
			
		if (fireRotator.transform.localEulerAngles.y > 90 && fireRotator.transform.localEulerAngles.y < 270) 
		{
			playerVisuals.transform.localScale = new Vector3 (-scaleX, 1, 1);
		}

		else 
		{
			playerVisuals.transform.localScale = new Vector3 (scaleX, 1, 1);
		}
	}
}