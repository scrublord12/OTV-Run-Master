using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Generator : MonoBehaviour {

    public GameObject platformLeft;
    public GameObject platformMiddle;
    public GameObject platformRight;
    public GameObject microphone;

    public Transform generationPoint;
    Transform thisTransform;

    public Transform lastPlatform;
    public float lastPlatformX;
    public float lastPlatformY;

    public float micDifferenceX;
    public float micDifferenceY;

    float platformWidth;
    float platformHeight;

    float fullPlatformWidth;

    public float sizeBetweenMinX;
    public float sizeBetweenMaxX;
    public float sizeBetweenMinY;
    public float sizeBetweenMaxY;

    void Start () {
        lastPlatformX = lastPlatform.position.x;
        lastPlatformY = lastPlatform.position.y;

        platformWidth = platformMiddle.GetComponent<BoxCollider2D>().size.x;
        platformHeight = platformMiddle.GetComponent<BoxCollider2D>().size.y;
    }

	void Update () {

        if (transform.position.x < generationPoint.position.x) {
            int platformSize = Random.Range(1, 6);
            float posX = pickX();
            float posY = pickY();

            createPlatform(platformSize, posX, posY);

            transform.position = new Vector3(lastPlatformX, lastPlatformY, 0);

        }

    }

    void createPlatform(int s, float x, float y) {
        bool createMic = true;
        float currentX = x;

        //make leftPlatform
        Instantiate(platformLeft, new Vector3(currentX, y, 0), transform.rotation);
        currentX += platformWidth;

        

        //make middlePlatform or middlePlatforms
        for (int i = 0; i < s; i++) {
            int ramdMic = Random.Range(0, 3);
            Instantiate(platformMiddle, new Vector3(currentX, y, 0), transform.rotation);
            if(ramdMic == 1 && createMic && i != 0 && i != s-1) {
                Instantiate(microphone, new Vector3(currentX - micDifferenceX, y + micDifferenceY, 0), transform.rotation);
                createMic = false;
            }
            if(i == 4) {
                createMic = true;
            }

            currentX += platformWidth;
        }

        //make rightPlatform
        Instantiate(platformRight, new Vector3(currentX, y, 0), transform.rotation);

        lastPlatformX = currentX;
        lastPlatformY = y;


    }

    float pickX() {
        return Random.Range(lastPlatformX + sizeBetweenMinX, lastPlatformX + sizeBetweenMaxX);
    }

    float pickY() {
        float y;

        if (lastPlatformY > 0.5f && lastPlatformY < 4.5f) {
            y = Random.Range(sizeBetweenMinX, sizeBetweenMaxX);
            int rand = Random.Range(0, 1);
            if (rand == 0) { //down
                y = lastPlatformY - y;
            }
            if (rand == 1) { //up
                y = lastPlatformY + y;
            }

            return y;
        }
        else if (lastPlatformY > 4.5f) {
            return Random.Range(0.5f, 3.5f);
        }
        else if (lastPlatformY < 0.5f) {
            return Random.Range(lastPlatformY + sizeBetweenMinY, lastPlatformY + sizeBetweenMaxY);
        }

        else return 0.5f;
    }
}
