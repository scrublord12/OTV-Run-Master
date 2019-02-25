using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;

    public float scoreCount;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public Transform player;

    Vector3 playerStartPoint;

    

	void Start () {

        playerStartPoint = player.position;

	}
	
	void Update () {

        if (player.transform.position.x >= playerStartPoint.x && player.position.y > -5 && !player.GetComponent<Player_Controller>().micTouched) {
            scoreIncreasing = true;
        }

        if (scoreIncreasing) {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);

	}
}
