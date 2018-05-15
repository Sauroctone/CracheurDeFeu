using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseInitiation : MonoBehaviour {

    public Transform[] waypoints;

    [Header("References")]
    public LineRenderer line;

    void Start()
    {
        line.positionCount = waypoints.Length;

        for (int i = 0; i < waypoints.Length; i++)
        {
            line.SetPosition(i, waypoints[i].position);
        }
    }

    
}

