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

	void Start()
	{
		player = GetComponent<PlayerController> ();
		bottles = GetComponent<BottleManager> ();
		scaleX = transform.localScale.x;
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
			fireBreath.transform.eulerAngles = new Vector3 (-180 + angle, -90, 90);
		}

		//REGLER CA
		if (fireBreath.transform.eulerAngles.x > (-180 + 90) || fireBreath.transform.eulerAngles.x < (-180 -90)) 
		{
			print ("hop");
			transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
		}
	}
}
