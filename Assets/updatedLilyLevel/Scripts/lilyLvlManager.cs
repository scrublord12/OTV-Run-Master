using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lilyLvlManager : MonoBehaviour
{
    public lilyPlayerController player;
    public Animator transition;
    public GameObject DeathMenu;

    public AudioSource levelSong;

    Vector3 playerInitialPosition;

    public GameObject cam;

    public Vector3 cameraInitialPosition;
    // Start is called before the first frame update
    void Start()
    {
        playerInitialPosition = player.GetComponent<Transform>().position;
        cameraInitialPosition = cam.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake() {

        transition.SetTrigger("Down");
            
    }

    public void Died()
    {
        levelSong.Stop();
        DeathMenu.GetComponent<Animator>().SetBool("Died", true);
        //player.gameObject.SetActive(false);



    }

    public void restartGame()
    {
        StartCoroutine("RestartGameCo");
    }

    IEnumerator RestartGameCo(){
        transition.SetTrigger("Full");
        yield return new WaitForSeconds(1f);
         SceneManager.LoadScene("lilyUpdatedLvl");
        
        
    }

    public void Menu()
    {

        StartCoroutine("menu");

    }

    IEnumerator menu()
    {

        transition.SetTrigger("Up");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Main_Menu");

    }
}
