using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrophoneController : MonoBehaviour {

    bool touched;

    Animator myAnim;

    Collider2D player;

    GameObject lilly;


    void Start() {

        myAnim = GetComponent<Animator>();
        lilly = GameObject.Find("Player");
        player = lilly.GetComponent<CircleCollider2D>();


    }

    void Update() {

        if (GetComponent<Collider2D>().IsTouching(player)) {

            touched = true;

            lilly.GetComponent<Player_Controller>().micTouched = true;

            myAnim.SetBool("Touched", touched);

  

        }


    }
}