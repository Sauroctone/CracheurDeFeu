using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour {

	public ParticleSystem fireBreath;
	private PlayerController player;
	private BottleManager bottles;

	void Start()
	{
		player = GetComponent<PlayerController> ();
		bottles = GetComponent<BottleManager> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (!fireBreath.isPlaying && Input.GetKeyDown ("e") && bottles.bottleCount > 0) 
		{
			fireBreath.Play ();
			player.speed = player.speedBreathing;
			bottles.bottleCount -= 1;
		}

		if (!fireBreath.isEmitting)
			player.speed = player.speedWalking;
	}
}
