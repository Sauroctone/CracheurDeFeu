using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBehaviour : MonoBehaviour {

    public Transform[] waypoints;
    public float burnSpeed;
    public float pathPercent;

    [Header("References")]
    public LineRenderer line;
    public GameObject fire;

    void Start()
    {
        line.positionCount = waypoints.Length;

        for (int i = 0; i < waypoints.Length; i++)
        {
            line.SetPosition(i, waypoints[i].position);
        }
    }

    void Update()
    {
        if (fire.activeSelf)
        {
            if (pathPercent < 1)
            {
                pathPercent += burnSpeed * Time.deltaTime;
                iTween.PutOnPath(fire, waypoints, pathPercent);
            }

            else
            {
                fire.SetActive(false);
            }
        }
    }
}


