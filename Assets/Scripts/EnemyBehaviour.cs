using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public float damage;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Floor")
		{
			speed = -speed;
		}
	}
}
