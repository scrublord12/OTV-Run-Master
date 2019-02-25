using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2DPlatformer : MonoBehaviour {

    public Player_Controller player;
    Vector3 lastPlayerPositionl;
    float distanceToMoveX;
    float distanceToMoveY = 0;
    float currentOffset = -6.5f;
    Vector3 offset;

    float lowY; //cant go below this point
    float lowX;

    public Transform offsetDown;
    public Transform offsetUp;


	void Start () {
        player = FindObjectOfType<Player_Controller>();
        lastPlayerPositionl = player.transform.position;

	}

    private void Update() {
        distanceToMoveX = player.transform.position.x - lastPlayerPositionl.x;
        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y + distanceToMoveY, transform.position.z);
        lastPlayerPositionl = player.transform.position;
    }




}
        
