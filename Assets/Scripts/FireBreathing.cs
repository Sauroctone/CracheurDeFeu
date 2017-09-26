using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour {

	public ParticleSystem fireBreath;
	private PlayerController player;

	void Start()
	{
		player = GetComponent<PlayerController> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (!fireBreath.isPlaying && Input.GetKeyDown ("e")) 
		{
			fireBreath.Play ();
			player.speed = player.speedBreathing;
		}

		if (!fireBreath.isEmitting)
			player.speed = player.speedWalking;
	}
}
