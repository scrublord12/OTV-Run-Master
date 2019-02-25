using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fedScoreManager : MonoBehaviour {

    // Use this for initialization
    public Text scoreText;

    public float scoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public Transform player;

    Vector3 playerStartPoint;

    void Start() {

        playerStartPoint = player.position;
        

    }

    void Update() {
        Debug.Log(playerStartPoint);
        Debug.Log(player.transform.position + " :current");

        if (player.GetComponent<Fed_Controller>().alreadyDead) {
            scoreIncreasing = false;
        }

        if (scoreIncreasing) {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }
        
        

        scoreText.text = "Score: " + Mathf.Round(scoreCount);

    }
}
