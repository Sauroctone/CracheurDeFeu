using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollision : MonoBehaviour {

	void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            EnemyBehaviour enemy = other.GetComponent<EnemyBehaviour>();

            if (!enemy.isOnFire)
                enemy.OnFire();
        }
    }
}
