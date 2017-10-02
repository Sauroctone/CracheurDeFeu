using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour {

	public float alcoholCount;

	void Update()
	{
		if (alcoholCount < 0)
			alcoholCount = 0;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Alcohol") 
		{
			alcoholCount += 3;

			GameObject.Destroy (col.gameObject);
		}
	}
}
