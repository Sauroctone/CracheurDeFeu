using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour {

    public float distanceFromChainEnd = 3;
    Rigidbody2D otherRB;
    public GameObject col;

	public void ConnectRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceFromChainEnd);

        otherRB = endRB;
    }

    void Update()
    {
        if (otherRB.gameObject == null && col != null && !col.activeSelf)
        {
            col.SetActive(true);
            Destroy(this);
        }
    }
}
