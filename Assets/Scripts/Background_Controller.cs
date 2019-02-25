using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Controller : MonoBehaviour {

    public Transform backgroundGenerationPoint;
    public GameObject background0;
    public GameObject background1;
    public GameObject background2;

    public float bgWidth;


	void Start () {
		
	}
	
	void Update () {
		
        if(transform.position.x < backgroundGenerationPoint.transform.position.x) {



            Instantiate(background0, new Vector3(transform.position.x + bgWidth, background0.transform.position.y, background0.transform.position.z), background0.transform.rotation);
            Instantiate(background1, new Vector3(transform.position.x + bgWidth, background1.transform.position.y, background1.transform.position.z), background1.transform.rotation);
            Instantiate(background2, new Vector3(transform.position.x + bgWidth - 20, background2.transform.position.y, background2.transform.position.z), background2.transform.rotation);

            transform.position = new Vector3(transform.position.x + bgWidth, transform.position.y, transform.position.z);
        }

	}
}
