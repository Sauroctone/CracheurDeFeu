﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlcoholManager : MonoBehaviour {

    [Range(0, 100)]
	public float alcoholCount;
    [Range(0, 100)]
	public float health = 100;
	public float healthDecay;
	public float bottleValue;
	public float alcoholBurn;
	public bool isBreathing;
	public bool isRecovering;

	public Slider lifeBar;
	public Slider alcoholBar;

	public EnemyBehaviour enemy;

	private Scene scene;

	void Start ()
	{
		scene = SceneManager.GetActiveScene();
	}

	void Update()
    { 
		if (isBreathing) 
		{
			alcoholCount -= alcoholBurn * Time.deltaTime;
		}

		if (Input.GetButton ("Drink") && health < 100 && alcoholCount > 0) 
		{
			alcoholCount -= alcoholBurn * Time.deltaTime;
			health += alcoholBurn * Time.deltaTime;
		}

		if (health > 0)
			health -= healthDecay * Time.deltaTime;

		lifeBar.value = health / 100;

		if (health <= 0)
		{
			SceneManager.LoadScene (scene.name);
		}

        alcoholBar.value = alcoholCount / 100;

        health = Mathf.Clamp(health, 0, 100);
        alcoholCount = Mathf.Clamp(alcoholCount, 0, 100);
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Alcohol" && alcoholCount < 100) 
		{
			alcoholCount += bottleValue;

			GameObject.Destroy (col.gameObject);
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Enemy" && !isRecovering)
		{ 
			health -= col.gameObject.GetComponentInParent<EnemyBehaviour>().damage;
			StartCoroutine ("DamageRecovery");
		}
	}

	IEnumerator DamageRecovery()
	{
		isRecovering = true;
		yield return new WaitForSeconds (2);
		isRecovering = false;
	}
}
