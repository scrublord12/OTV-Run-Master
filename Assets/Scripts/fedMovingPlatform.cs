using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fedMovingPlatform : MonoBehaviour {

    public string platformSize;

    public float smallPlatformRightRestriction;
    public float smallPlatformLeftRestriction;
    public float bigPlatformRightRestriction;
    public float bigPlatformLeftRestriction;

    public float restrictionLeft, restrictionRight;

    public float speed;
    public bool left, right;

    // Use this for initialization
    void Start() {
        right = false;
        left = false;
        if (platformSize == "small") {

            restrictionLeft = smallPlatformLeftRestriction;
            restrictionRight = smallPlatformRightRestriction;

        }
        if (platformSize == "big") {
            restrictionLeft = bigPlatformLeftRestriction;
            restrictionRight = bigPlatformRightRestriction;
        }

        if (transform.position.x > 0) {
            //GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, GetComponent<Rigidbody2D>().velocity.y);
            left = true;
        }
        if (transform.position.x < 0) {
           // GetComponent<Rigidbody2D>().velocity = new Vector3(speed, GetComponent<Rigidbody2D>().velocity.y);
            right = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.x < restrictionLeft) {

            //go right
            right = true;
            left = false;

        }
        if(transform.position.x > restrictionRight) {

            //go left
            right = false;
            left = true;

        }

        

        if (right) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (left) {
            GetComponent<Rigidbody2D>().velocity = new Vector3(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }

	}
}
