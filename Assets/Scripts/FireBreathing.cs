using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour {

	public ParticleSystem fireBreath;
	private PlayerController player;
	private AlcoholManager alcohol;
	private Light myLight;

	public GameObject playerVisuals;
	public GameObject fireRotator;

	private float rightStickX;
	private float rightStickY;
	private float angle;
	private float scaleX;
	private float fireRotationX;
	public float lightLerp;

	//public float initStartLifeLow;
	//public float initStartLifeHigh;
	//public float startLifeLow;
	//public float startLifeHigh;
	//public float startLifeIncrement;
	//public float startLifeLimit;

	//public float initRateOverTime;
	//public float rateOverTime;
	//public float rateIncrement;
	//public float rateLimit;

	//private float initLightRange;
	//public float lightRangeIncrement;
	//public float lightRangeLimit;

	void Start()
	{
		player = GetComponent<PlayerController> ();
		alcohol = GetComponent<AlcoholManager> ();
		//light = fireBreathLight.GetComponent<Light> ();

		scaleX = playerVisuals.transform.localScale.x;
/*		startLifeLow = initStartLifeLow;
		startLifeHigh = initStartLifeHigh;
		rateOverTime = initRateOverTime;
*/
		//initLightRange = light.range;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!fireBreath.isEmitting && Input.GetButtonDown ("BreatheFire") && alcohol.alcoholCount > 0) 
		{
			fireBreath.Play ();
            
			//fireBreathLight.SetActive (true);
		}

		if (Input.GetButton ("BreatheFire") && alcohol.alcoholCount > 0) 
		{
            if (player.isGrounded)
                player.speed = player.speedBreathing;

            alcohol.isBreathing = true;
            /*
                        if (startLifeHigh < startLifeLimit)
                        {
                            var main = fireBreath.main;
                            startLifeLow += startLifeIncrement * Time.deltaTime;
                            startLifeHigh += startLifeIncrement * Time.deltaTime;
                            main.startLifetime = new ParticleSystem.MinMaxCurve (startLifeLow, startLifeHigh);
                        }

                        if (rateOverTime < rateLimit)
                        {
                            var emission = fireBreath.emission;
                            rateOverTime += rateIncrement * Time.deltaTime;
                            emission.rateOverTime = new ParticleSystem.MinMaxCurve (rateOverTime);
                        }

                        if (light.range < lightRangeLimit) 
                        {
                            light.range += lightRangeIncrement * Time.deltaTime; 
                        } */
        }

        if (fireBreath.isPlaying && Input.GetButtonUp ("BreatheFire") || fireBreath.isPlaying && alcohol.alcoholCount <= 0) 
		{
			fireBreath.Stop ();
			alcohol.isBreathing = false;
/*
			startLifeLow = initStartLifeLow;
			startLifeHigh = initStartLifeHigh;
			rateOverTime = initRateOverTime;
*/
	//		light.range = initLightRange;
			//fireBreathLight.SetActive (false);
		}

		if (!fireBreath.isEmitting && player.isGrounded)
			player.speed = player.speedWalking;

		rightStickX = Input.GetAxis("RS_Vertical");
		rightStickY = Input.GetAxis("RS_Horizontal");
		angle = Mathf.Atan2(rightStickX, rightStickY) * Mathf.Rad2Deg;

		if (rightStickX != 0 || rightStickY != 0) 
		{
			fireRotator.transform.localEulerAngles = Vector3.Lerp (fireRotator.transform.localEulerAngles, new Vector3 (0, angle, 0), lightLerp);
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