using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Fed_Controller : MonoBehaviour {

    public float jumpForce;
    public float speed;

    public float jumpTime;
    float jumpTimeCounter;

    public bool isGrounded;

    public bool notOnMenu;

    bool startRunningLeft;
    bool startRunningRight;

    public LayerMask groundLayer;

    Animator myAnim;
    Collider2D myCollider;
    Rigidbody2D myRb;

    public Transform groundCheck;
    public float groundCheckRadius;

    public bool leakTouched;

    bool stoppedJumping;

    public bool alreadyDead;

    public GameObject[] LeakHitSounds;

    public GameObject[] FallSounds;

    public GameObject[] JumpSounds;

    bool alreadyDeadLeak;

    public GameObject levelManager;

    public Transform deathPoint;

    public bool inMenu;

    public Button jumpButton;
    

    public bool jump, right, left;

    public Button rightButton;

    public Button leftButton;

    bool buttonsClicked;

    public RectTransform[] uiElements;




    // Use this for initialization
    void Start () {

        myRb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        myAnim = GetComponent<Animator>();

        jumpTimeCounter = jumpTime;

        stoppedJumping = true;

        alreadyDead = false;

    }
	


    public void turnRight() {

        right = true;
        jump = false;
        left = false;
        //buttonsClicked = true;

    }

    public void turnLeft() {

        left = true;
        right = false;
        jump = false;
        //buttonsClicked = true;

    }

    public void jumpUp() {

        jump = true;

    }
    // Update is called once per frame
    void Update() {

        Debug.Log(isMouseOverUI() + "llll");


        if (EventSystem.current.IsPointerOverGameObject()) {
            jump = false;
        }
        else {
            jump = true;
        }

        if (inMenu) {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            myAnim.SetFloat("speed", Mathf.Abs(myRb.velocity.x));
            myAnim.SetBool("isGrounded", isGrounded);
            myAnim.SetFloat("verticalSpeed", myRb.velocity.y);

            myRb.velocity = new Vector2(speed, myRb.velocity.y);


        }
        else {

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && isGrounded && jump && !isMouseOverUI()) {

                myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
                //JumpSounds[Random.Range(0, JumpSounds.Length)].GetComponent<AudioSource>().Play();
                //Debug.Log("hmm");
                //Debug.Log(Input.mousePosition.x + +Input.mousePosition.y);
                

                stoppedJumping = false;
            }




            if ((Input.GetKeyDown(KeyCode.A) || left)) {
                myRb.velocity = new Vector2(-speed, myRb.velocity.y);
                if (transform.localScale.x > 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            else
             if ((Input.GetKeyDown(KeyCode.D) || right) ) {
                myRb.velocity = new Vector2(speed, myRb.velocity.y);
                if (transform.localScale.x < 0)
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            }
            
            if (( Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) && !stoppedJumping) {

                if (jumpTimeCounter > 0) {
                    myRb.velocity = new Vector2(myRb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;

                }

            }

            

            if ((Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0) )) {
               // jumpTimeCounter = 0;
                stoppedJumping = true;
            }

            if (transform.position.y < deathPoint.position.y) {
                alreadyDead = true;
                Debug.Log("hi");
            }

            if (isGrounded && stoppedJumping) {
                jumpTimeCounter = jumpTime;
            }

            if (transform.position.y < deathPoint.position.y) {
                alreadyDead = true;
            }

            if (alreadyDead) {
                levelManager.GetComponent<fedLevelManager>().Died();
                //alreadyDead = false;
                Debug.Log("died");
            }

            myAnim.SetFloat("speed", Mathf.Abs(myRb.velocity.x));
            myAnim.SetBool("isGrounded", isGrounded);
            myAnim.SetFloat("verticalSpeed", myRb.velocity.y);


        }
        

    }
    public bool isMouseOverUI() {
        if(Input.touchCount == 0) {
            return false;
        }
        Vector2 mousePosition = Input.GetTouch(0).position;
        foreach (RectTransform elem in uiElements) {
            if (!elem.gameObject.activeSelf) {
                continue;
            }
            Vector3[] worldCorners = new Vector3[4];
            elem.GetWorldCorners(worldCorners);

            if (mousePosition.x >= worldCorners[0].x && mousePosition.x < worldCorners[2].x
               && mousePosition.y >= worldCorners[0].y && mousePosition.y < worldCorners[2].y) {
                return true;
            }
        }
        return false;
    }
}
