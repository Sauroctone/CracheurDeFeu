using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float speed;
    public float burningSpeed;
	private Rigidbody2D rb;
	public float damage;
    public GameObject fire;
    public float health;
    public float healthBurn;
    public LayerMask floorMask;
    ContactFilter2D filter;
    public Collider2D[] resultArray;
    int results;

    void Start()
	{
		rb = GetComponent<Rigidbody2D> ();
        filter.SetLayerMask(floorMask);
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

    void Update()
    {
        if (fire.activeSelf)
        {
            health -= healthBurn * Time.deltaTime;
        }

        if (health <= 0)
        {
            gameObject.SetActive(false);
        }

        resultArray = new Collider2D[5];
        results = Physics2D.OverlapBox(transform.position + new Vector3(.5f * Mathf.Sign(speed), 0, 0), new Vector2(.3f, .3f), 0f, filter, resultArray);

        if (results == 0)
        {
            speed = -speed;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position + new Vector3(.5f * Mathf.Sign(speed), 0, 0), new Vector3(.3f, .3f, 1f));
    }

    void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag == "Floor")
		{
			speed = -speed;
		}
	}
}
