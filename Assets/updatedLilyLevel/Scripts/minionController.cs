using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startFirePoint;
    Animator myAnim;
    Collider2D myCollider;
    Transform destroyPoint;
    bool fire2 = true;

    bool fire = true;

    public GameObject fireBall;
    void Start()
    {
        myAnim = GetComponent<Animator>();
        startFirePoint = GameObject.FindGameObjectWithTag("startFirePoint").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").transform.position.x > startFirePoint.transform.position.x && fire){
            myAnim.SetBool("fire", fire);
            Instantiate(fireBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            fire = false;
        }

        if(GameObject.FindGameObjectWithTag("Player").transform.position.x > GameObject.FindGameObjectWithTag("firePoint2").transform.position.x && fire2){
            fire2 = true;
            myAnim.SetBool("fire", 0==0);
            Instantiate(fireBall, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            fire2 = false;
        }
        myAnim.SetBool("fire", false);

        if(transform.position.x < GameObject.FindGameObjectWithTag("Player").transform.position.x){
            myAnim.SetBool("die", 0==0);
            StartCoroutine("destroy");
        }
    }

    IEnumerator destroy(){
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
