using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    public string lilyLevel;

    public string fedLevel;

    public Animator transition;

    public Animator move;



    public void playGame() {

        StartCoroutine("play");

    }

    private void Awake() {

        transition.SetTrigger("Down");
    }

    IEnumerator play() {

        move.SetTrigger("move");
        yield return new WaitForSeconds(0f);
        //SceneManager.LoadScene(playGameLevel);


    }

    public void back() {

        move.SetTrigger("moveBack");

    }

    public void quitGame() {
        Application.Quit();
    }

    public void fedPlay() {

        StartCoroutine("fed");

    }

    public void lilyPlay() {

        StartCoroutine("lily");

    }

    IEnumerator fed() {

        transition.SetTrigger("Up");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(fedLevel);


    }

    IEnumerator lily() {

        transition.SetTrigger("Up");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(lilyLevel);


    }



}
