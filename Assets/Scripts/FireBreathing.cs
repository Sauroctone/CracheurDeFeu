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
	public float initStartRotLow;
	public float initStartRotHigh;
	public float startRotLow;
	public float startRotHigh;

	public GameObject playerVisuals;
	public GameObject fireRotator;


	void Start()
	{
		player = GetComponent<PlayerController> ();
		bottles = GetComponent<BottleManager> ();
		scaleX = playerVisuals.transform.localScale.x;
		startRotLow = initStartRotLow;
		startRotHigh = initStartRotHigh;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!fireBreath.isPlaying && Input.GetButtonDown ("BreatheFire") && bottles.alcoholCount > 0) 
		{
			fireBreath.Play ();
			player.speed = player.speedBreathing;
		}

		if (Input.GetButton ("BreatheFire") && bottles.alcoholCount > 0) 
		{
			bottles.alcoholCount -= Time.deltaTime;
			var main = fireBreath.main;
			//main.startRotation = fireRotator.transform.eulerAngles.y;
			startRotLow += 0.1f * Time.deltaTime;
			startRotHigh += 0.1f * Time.deltaTime;
			main.startLifetime = new ParticleSystem.MinMaxCurve (startRotLow, startRotHigh);
		}

		if (fireBreath.isPlaying && Input.GetButtonUp ("BreatheFire") || fireBreath.isPlaying && bottles.alcoholCount <= 0) 
		{
			fireBreath.Stop ();
			var main = fireBreath.main;
			startRotLow = initStartRotLow;
			startRotHigh = initStartRotHigh;
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