using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {

	void OnParticleCollision(GameObject other)
    {
        if (other.transform != transform.parent)
        {
            //if (other.tag == "Enemy")
            //{
            //    EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();

            //    if (!enemy.isOnFire)
            //        enemy.OnFire();
            //}

            //if (other.tag == "Link")
            //{
            //    other.transform.parent.GetComponent<Rope>().BurnLink(other);
            //}

            //if (other.tag == "TNT")
            //{
            //    TNTBehaviour tnt = other.GetComponent<TNTBehaviour>();

            //    if (!tnt.isOnFire)
            //        tnt.OnFire();
            //}

            //if (other.tag == "TorchOff")
            //{
            //    other.transform.Find("Fire").gameObject.SetActive(true);
            //    other.transform.Find("WallLight").gameObject.SetActive(true);
            //    other.tag = "Untagged";
            //}

            //if (other.tag == "Fuse")
            //{
            //    Transform fire = other.transform.parent.Find("OnFire");
            //    fire.gameObject.SetActive(true);
            //}
        }
    }
}
