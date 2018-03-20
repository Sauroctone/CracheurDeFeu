using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingFire : MonoBehaviour {

    public GameObject fireSelf;

	void OnParticleCollision(GameObject other)
    { 
        if (other.tag == "Fire" 
            && !fireSelf.activeSelf
            && other.transform.parent != transform.parent) //bug possible : si les deux n'ont pas de parent ?
        {
            fireSelf.SetActive(true);
        }
    }
}
