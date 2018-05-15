using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOnFire : MonoBehaviour {

	void Start()
    {
        StartCoroutine(OnFire());
    }

    IEnumerator OnFire()
    {
        yield return new WaitForSeconds(1f);
        transform.parent.parent.GetComponent<Rope>().BurnLink(transform.parent.gameObject);
    }
}
