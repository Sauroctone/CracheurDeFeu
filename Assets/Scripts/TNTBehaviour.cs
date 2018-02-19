using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTBehaviour : MonoBehaviour {

    public ParticleSystem fire;
    public bool isOnFire;
    public float burnTimer;
    public GameObject explosion;

	public void OnFire()
    {
        fire.Play();
        isOnFire = true;
        StartCoroutine(FireCor());
    }

    IEnumerator FireCor()
    {
        yield return new WaitForSeconds(burnTimer);
        explosion.SetActive(true);
    }
}
