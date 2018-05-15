using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour {

    public int links = 7;
    public float burnTime;
    List<GameObject> linkArray = new List<GameObject>();

    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public Weight weight;
    public LineRenderer line;

	void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        line.positionCount = links+1;
        line.SetPosition(0, hook.transform.position);

        Rigidbody2D previousRB = hook;
        for (int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            linkArray.Add(link);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            line.SetPosition(i+1, link.transform.position);

            if (i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }

            else
            {
                weight.ConnectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }

  /*  void Update()
    {
        for (int i = 0; i < linkArray.Count; i++)
        {
            line.SetPosition(i+1, linkArray[i].transform.position);
        }
    }*/

    public void BurnLink(GameObject _link)
    {
        linkArray.Remove(_link);
        Destroy(_link);
    }
}