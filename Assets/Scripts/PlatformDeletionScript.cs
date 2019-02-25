using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDeletionScript : MonoBehaviour {

    public GameObject platformDestructionPoint;
    public GameObject platformGenerationPoint;
	void Start () {
        platformDestructionPoint = GameObject.Find("DeletePoint");

	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < platformDestructionPoint.transform.position.x ) {
            Destroy(gameObject);
        }
	}
}
