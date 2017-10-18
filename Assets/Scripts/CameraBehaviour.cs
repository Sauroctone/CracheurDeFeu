using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

	public Transform target;
	public float cameraLerp;
	private Vector3 velocity = Vector3.zero;

	void Update () 
	{
		transform.position = Vector3.SmoothDamp (transform.position, new Vector3 (target.position.x, target.position.y, transform.position.z), ref velocity, cameraLerp);

	}
}
