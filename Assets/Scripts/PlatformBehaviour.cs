using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour {

    public Rigidbody2D rb;

	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }

        if (col.tag == "Floor")
        {
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(this);
        }
    }
}
