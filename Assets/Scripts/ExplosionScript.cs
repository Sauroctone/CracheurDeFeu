using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

    public float damage;

    void Start()
    {
        Destroy(transform.parent.gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<AlcoholManager>().health -= damage;
        }
            
        if (col.tag == "Enemy")
        {
            col.gameObject.SetActive(false);
        }
    }
}
