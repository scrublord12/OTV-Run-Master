using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fed_Platform_Deletion : MonoBehaviour {

    GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {

        platformDestructionPoint = GameObject.Find("DeletePoint");

    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y < platformDestructionPoint.transform.position.y) {
            Destroy(gameObject);
        }

    }
}
