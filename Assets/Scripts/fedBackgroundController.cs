using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fedBackgroundController : MonoBehaviour {

    public GameObject sky;

    public float size;
    public float increment;

    public Transform creationPoint;

	// Use this for initialization
	void Start () {

        increment = 21.6f;
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.y < creationPoint.transform.position.y) {

            Instantiate(sky, new Vector3(transform.position.x, transform.position.y + size, sky.transform.position.z), sky.transform.rotation);
            transform.position = new Vector3(transform.position.x, transform.position.y + size);


        }

	}
}
