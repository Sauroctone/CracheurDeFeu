using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlcoholManager : MonoBehaviour {

	public float alcoholCount;
	public float health = 100;
	public float healthDecay;
	public float bottleValue;
	public float alcoholBurn;
	public bool isBreathing;

	public Slider lifeBar;
	public Slider alcoholBar;

	void Update()
	{
		if (alcoholCount < 0)
			alcoholCount = 0;

		alcoholBar.value = alcoholCount;

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

		lifeBar.value = health;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Alcohol") 
		{
			alcoholCount += bottleValue;

			GameObject.Destroy (col.gameObject);
		}
	}
}
