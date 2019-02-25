using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fed_Platform_Generator : MonoBehaviour {

    public GameObject smallPlatform;
    public GameObject bigPlatform;
    public GameObject smallMovingPlatform;
    public GameObject bigMovingPlatform;
    public GameObject singlePlatform;

    public Transform generationPoint;
    Transform thisTransform;

    public Transform lastPlatform;

    float platformWidth;
    float platformHeight;

    float smallPlatformMultiplier;
    float bigPlatformMultiplier;

    public float sizeBetweenMinX;
    public float sizeBetweenMaxX;
    public float sizeBetweenMinY;
    public float sizeBetweenMaxY;

    public float lastPlatformX;
    public float lastPlatformY;

	// Use this for initialization
	void Start () {
        lastPlatformX = lastPlatform.position.x;
        lastPlatformY = lastPlatform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
        if(transform.position.y < generationPoint.position.y) {

            int pickPlatform = Random.Range(1, 7);
            float posX = pickX();
            float posY = pickY();

            createPlatform(pickPlatform, posX, posY);
        }
	}

    void createPlatform(int pickPlatform, float posX, float posY) {

        if(pickPlatform <= 3) {
            Instantiate(bigPlatform, new Vector3(posX, posY, bigPlatform.transform.position.z), transform.rotation);
        }
        if (pickPlatform <= 6 && pickPlatform >= 4) {
            if (lastPlatformX > 0) {
                Instantiate(smallPlatform, new Vector3(Random.Range(-5, -4), posY, smallPlatform.transform.position.z), transform.rotation);
            }
            else {
                Instantiate(smallPlatform, new Vector3(Random.Range(5, 4), posY, smallPlatform.transform.position.z), transform.rotation);
            }
        }
        if (pickPlatform == 8) {
            Instantiate(bigMovingPlatform, new Vector3(posX, posY, bigMovingPlatform.transform.position.z), transform.rotation);
        }
        if (pickPlatform == 7) {
            Instantiate(smallMovingPlatform, new Vector3(posX, posY, smallMovingPlatform.transform.position.z), transform.rotation);
        }

        
        lastPlatformX = posX;
        lastPlatformY = posY;
        transform.position = new Vector3(transform.position.x, lastPlatformY, transform.position.z);

    }

    float pickX() {
        if(lastPlatformX > 0) {
            return Random.Range(-6, -5.5f);
        }else {
            return Random.Range(6, 5.5f);
        }

    }

    float pickY() {

        return Random.Range(lastPlatformY + sizeBetweenMinY, lastPlatformY + sizeBetweenMaxY);

    }
}
