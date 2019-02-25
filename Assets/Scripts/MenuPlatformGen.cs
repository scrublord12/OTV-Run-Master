using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPlatformGen : MonoBehaviour {

    public Transform platformGenPoint;
    public GameObject Platforms;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.x < platformGenPoint.position.x) {
            Instantiate(Platforms, new Vector3(transform.position.x + 1, Platforms.transform.position.y, 0), Platforms.transform.rotation);

            transform.position = new Vector3(transform.position.x + 23, Platforms.transform.position.y, 0);

        }

	}
}
