using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTBehaviour : MonoBehaviour {

    public float burnTimer;
    public GameObject explosion;

	void Start ()
    { 
        StartCoroutine(FireCor());
    }

    IEnumerator FireCor()
    {
        yield return new WaitForSeconds(burnTimer);
        explosion.SetActive(true);
    }
}
