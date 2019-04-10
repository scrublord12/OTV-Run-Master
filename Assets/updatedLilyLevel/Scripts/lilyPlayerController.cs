using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilyPlayerController : MonoBehaviour {

    public float jump_Force;
    public float speed;
    public float speed_Multiplier;
    public float speed_Increase_Milestone;
    float speed_Milestone_Count;
    public float jump_Time;
    float jump_Time_Counter;
    public bool isGrounded;
    public bool notOnMenu;
    public LayerMask groundLayer;
    Animator myAnim;
    Collider2D myCollider;
    Rigidbody2D rb;
    public Transform dogModeStart;
    public Transform dogModeEnd;
    public Transform beeModeStart;
    public Transform beeModeEnd;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool obstacleHit;
    bool stoppedJumping;
    public bool alreadyDead;
    public GameObject[] MicHitSounds;
    public GameObject[] FallSounds;
    public GameObject[] JumpSounds;
    bool alreadyDeadObstacle;
    public bool dogMode;
    public bool beeMode;
    public float dogModeSpeed, dogModeJumpForce;
    public float beeModeSpeed, beeModeJumpForce;
    public float normalSpeed, normalJumpForce;

    public Transform lilyStartPosition;

    public Transform[] deathPoint;

    public int deathPointTracker;

    public bool reset;

    public lilyLvlManager lvlManager;
    void Start() {

        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnim = GetComponent<Animator>();

        jump_Time_Counter = jump_Time;

        stoppedJumping = true;
        alreadyDead = false;

    }

    void Update() {
        if(alreadyDead){
           //start death transition to score menu
           //start lily death animation

           //change the z coord so lily falls off the platform

           //detach lily from the camera move controller

           //make lily object invisible

           //transition to score menu

        }else{
            rb.velocity = new Vector2(speed, rb.velocity.y);

            //isGrounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

            if ((Input.GetMouseButtonDown(0) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded) && speed > 0) {

                rb.velocity = new Vector2(rb.velocity.x, jump_Force);
                //JumpSounds[Random.Range(0, JumpSounds.Length)].GetComponent<AudioSource>().Play();

                stoppedJumping = false;
            }

            if (((Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) && speed > 0) {

                if (jump_Time_Counter > 0) {
                    rb.velocity = new Vector2(rb.velocity.x, jump_Force);
                    jump_Time_Counter -= Time.deltaTime;
                }
            }

            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) && speed > 0) {
                jump_Time_Counter = 0;
                stoppedJumping = true;
            }

            if (isGrounded) {
                jump_Time_Counter = jump_Time;
            }
            speed = normalSpeed;
            jump_Force = normalJumpForce;

            //dogmode = true condition
            if(transform.position.x > dogModeStart.transform.position.x){
                dogMode = true;

            }
            
            if(dogMode == true){
                
                //change animations to dog animations
                myAnim.SetBool("dogMode", dogMode);
                myAnim.SetBool("Grounded", isGrounded);
                myAnim.SetFloat("Speed", rb.velocity.x);
                myAnim.SetFloat("Vertical_Speed", rb.velocity.y);

                //increase speed
                speed = dogModeSpeed;

                //increase jump Force
                jump_Force = dogModeJumpForce;

                transform.localScale = new Vector3(2, 2, 1);
            }else{
                transform.localScale = new Vector3(-2, 2, 1);
                speed = normalSpeed;
                jump_Force = normalJumpForce;
                myAnim.SetBool("dogMode", dogMode);
                myAnim.SetBool("Grounded", isGrounded);
                myAnim.SetFloat("Speed", rb.velocity.x);
                myAnim.SetFloat("Vertical_Speed", rb.velocity.y);

            }
        }

        if(transform.position.x > deathPoint[deathPointTracker].transform.position.x){
            deathPointTracker++;
        }

        if(transform.position.y < deathPoint[deathPointTracker].transform.position.y){
            alreadyDead = true;
            lvlManager.Died();
        }

    }

    public void resetLevel(){

    }
}


