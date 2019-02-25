using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallController : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject player;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-18f, GetComponent<Rigidbody2D>().velocity.y);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<CircleCollider2D>().IsTouching(player.GetComponent<CircleCollider2D>())){
            GameObject.FindGameObjectWithTag("Player").GetComponent<lilyPlayerController>().alreadyDead = true;
        }

        if(transform.position.x < GameObject.FindGameObjectWithTag("startFirePoint").transform.position.x){
            Destroy(gameObject);
        }

        
    }
}
