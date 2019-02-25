using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

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

    public Transform groundCheck;
    public float groundCheckRadius;

    public GameManager gm;

    public bool micTouched;

    bool stoppedJumping;

    public bool alreadyDead;

    public GameObject[] MicHitSounds;

    public GameObject[] FallSounds;

    public GameObject[] JumpSounds;

    bool alreadyDeadMic;

    void Start() {

        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnim = GetComponent<Animator>();

        jump_Time_Counter = jump_Time;

        stoppedJumping = true;

        alreadyDead = false;

  

    }

    void Update() {

        if (!notOnMenu) {
            speed_Multiplier = 1;
        }

        rb.velocity = new Vector2(speed, rb.velocity.y);

        //isGrounded = Physics2D.IsTouchingLayers(myCollider, groundLayer);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(transform.position.x > speed_Milestone_Count) {
            speed_Milestone_Count += speed_Increase_Milestone;

            speed_Increase_Milestone = speed_Increase_Milestone * speed_Multiplier;
            speed = speed * speed_Multiplier;

           // speed_Milestone_Count = speed_Increase_Milestone;
        }

        if ((Input.GetMouseButtonDown(0) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded) && speed > 0) {

            rb.velocity = new Vector2(rb.velocity.x, jump_Force);
            JumpSounds[Random.Range(0, JumpSounds.Length)].GetComponent<AudioSource>().Play();

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

        myAnim.SetBool("Grounded", isGrounded);
        myAnim.SetFloat("Speed", rb.velocity.x);
        myAnim.SetFloat("Vertical_Speed", rb.velocity.y);

        if((transform.position.y <= -5f || micTouched) && !alreadyDead) {
            gm.Died();
            alreadyDead = true;
        }

        if (micTouched && !alreadyDeadMic) {
            MicHitSounds[Random.Range(0, MicHitSounds.Length)].GetComponent<AudioSource>().Play();
            speed = 0;
        }

        if (transform.position.y <= -5f && !alreadyDeadMic) {
            FallSounds[Random.Range(0, FallSounds.Length)].GetComponent<AudioSource>().Play();
            
        }

        alreadyDeadMic = alreadyDead;
    }
}


