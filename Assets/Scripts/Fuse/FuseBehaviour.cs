using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBehaviour : MonoBehaviour {

    public float burnSpeed;
    float pathPercent;
    public GameObject fire;
    public FuseInitiation fuse;

    void Update()
    {
        if (fire.activeSelf)
        {
            if (pathPercent < 1)
            {
                pathPercent += burnSpeed * Time.deltaTime;
                iTween.PutOnPath(fire, fuse.waypoints, pathPercent);
            }

            else
            {
                fire.SetActive(false);
            }
        }
    }
}
