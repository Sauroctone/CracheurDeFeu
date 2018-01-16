using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float speed;
	private Rigidbody2D rb;
	public float damage;
    public bool isOnFire;
    public ParticleSystem fire;
    public float health;
    public float healthBurn;

	void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

    void Update()
    {
        if (isOnFire)
        {
            health -= healthBurn * Time.deltaTime;
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }
    }

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Floor")
		{
			speed = -speed;
		}
	}

    public void OnFire()
    {
        isOnFire = true;
        fire.Play();
        speed = speed * 2;
    }
}
