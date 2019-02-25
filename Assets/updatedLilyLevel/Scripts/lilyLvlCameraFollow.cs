using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class lilyLvlCameraFollow : MonoBehaviour {

    public Transform player;
    public Vector2 margin, smoothing;

    public BoxCollider2D bounds;

    public Vector3 min, max;

    public bool isFollowing{get; set;}
    float distanceToMoveX;  
    Vector3 lastPlayerPositionl;

    public void Start(){
        isFollowing = true;
        lastPlayerPositionl = player.transform.position;

    }

    public void Update(){
        distanceToMoveX = player.transform.position.x - lastPlayerPositionl.x;
        var x = transform.position.x;
        var y = transform.position.y;
        transform.position = new Vector3(transform.position.x + distanceToMoveX, transform.position.y, transform.position.z);
        if(isFollowing){
            // if(Mathf.Abs(x - player.position.x) > margin.x){
            //     x = Mathf.Lerp(x, player.position.x, smoothing.x * Time.deltaTime);
            // }
            if(Mathf.Abs(y - player.position.y) > margin.y){
                y = Mathf.Lerp(y, player.position.y, smoothing.y * Time.deltaTime);
            }

            var cameraHalfWidth = GetComponent<Camera>().orthographicSize * ((float) Screen.width / Screen.height);
            //x = Mathf.Clamp(x, min.x + cameraHalfWidth, max.x - cameraHalfWidth);
            y = Mathf.Clamp(y, min.y + GetComponent<Camera>().orthographicSize, max.y - GetComponent<Camera>().orthographicSize);
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
        lastPlayerPositionl = player.transform.position;
    }




}
        
