using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fedLevelManager : MonoBehaviour {

    public fedScoreManager score;

    public GameObject DeathMenu;
    public Animator transition;

    public Fed_Controller fed;

    Fed_Platform_Deletion[] platformList;

    Vector3 fedStartPoint;

    Vector3 platformStartPoint;

    public Transform platformGenerator;

    public GameObject camera;

    Vector3 initialCameraPosition;

    public GameObject platformGenerationPoint;

    public GameObject initialPlatform;

    float initialMilestoneCount;

    float initialSpeedMultipler;

    private void Awake() {

        transition.SetTrigger("Down");
        

    }
    // Use this for initialization
    void Start () {

        fedStartPoint = fed.transform.position;

        platformStartPoint = platformGenerator.position;

        initialCameraPosition = camera.transform.position;

        platformStartPoint = platformGenerationPoint.transform.position;

        initialSpeedMultipler = camera.GetComponent<CameraFollowFedLevel>().speedMultiplier;

        initialMilestoneCount = camera.GetComponent<CameraFollowFedLevel>().milestoneCount;





    }
	
	// Update is called once per frame
	void Update () {

        

	}

    public void replay() {

        StartCoroutine("Replay");

    }

    IEnumerator Replay() {

        transition.SetTrigger("Full");

        yield return new WaitForSeconds(0.5f);
        fed.gameObject.SetActive(false);

        platformList = FindObjectsOfType<Fed_Platform_Deletion>();


        DeathMenu.GetComponent<Animator>().SetBool("Died", false);

        for (int i = 0; i < platformList.Length; i++) {

            Destroy(platformList[i].gameObject);
        }

        camera.GetComponent<CameraFollowFedLevel>().camMove = false;

        yield return new WaitForSeconds(0.5f);
        platformGenerationPoint.transform.position = platformStartPoint;
        fed.transform.position = fedStartPoint;
        camera.transform.position = initialCameraPosition;

        platformGenerator.GetComponent<Fed_Platform_Generator>().lastPlatformX = initialPlatform.transform.position.x;
        platformGenerator.GetComponent<Fed_Platform_Generator>().lastPlatformY = initialPlatform.transform.position.y;

        camera.GetComponent<CameraFollowFedLevel>().camMove = false;

        camera.GetComponent<CameraFollowFedLevel>().milestoneCount = initialMilestoneCount;

        camera.GetComponent<CameraFollowFedLevel>().speedMultiplier = initialSpeedMultipler;

        score.scoreIncreasing = true;

        score.scoreCount = 0;

        fed.gameObject.SetActive(true);

        fed.alreadyDead = false;

        fed.left = false;
        fed.right = false;
        
        
        

        




    }

    public void Died() {

        score.scoreIncreasing = false;
        DeathMenu.GetComponent<Animator>().SetBool("Died", true);
        fed.gameObject.SetActive(false);

    }

    public void Menu() {

        StartCoroutine("menu");
    }

    IEnumerator menu() {

        transition.SetTrigger("Up");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main_Menu");

    }


}
