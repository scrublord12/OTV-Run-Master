using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicButtonController : MonoBehaviour {


    //the current music button in the scene this object is in
    public Button musicButton;

    //use this sprite when the music is playing
    public Sprite musicOn;

    //use this sprite when music is not playing
    public Sprite musicOff;

    //all the audio files tagged with music
    GameObject[] audio;


	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
		


	}

    private void Awake() {

        audio = GameObject.FindGameObjectsWithTag("Music");

        if (PlayerPrefs.HasKey("Music")) {

        } else {

            PlayerPrefs.SetInt("Music", 0);

        }

        if(PlayerPrefs.GetInt("Music") == 1) {
            musicButton.image.sprite = musicOff;
            for (int i = 0; i < audio.Length; i++) { 
                audio[i].GetComponent<AudioSource>().volume = 0;
            }

        }

        if (PlayerPrefs.GetInt("Music") == 0) {
            musicButton.image.sprite = musicOn;
            for (int i = 0; i < audio.Length; i++) {
                audio[i].GetComponent<AudioSource>().volume = 1;
            }

        }


    }

    public void pressed() {

        

        //0 is true, 1 is false
        if(PlayerPrefs.GetInt("Music") == 0) {

            PlayerPrefs.SetInt("Music", 1);

            musicButton.image.sprite = musicOff;

            if (PlayerPrefs.GetInt("Music") == 1) {

                for (int i = 0; i < audio.Length; i++) {
                    audio[i].GetComponent<AudioSource>().volume = 0;
                }

            }



        } else if(PlayerPrefs.GetInt("Music") == 1) {

            PlayerPrefs.SetInt("Music", 0);

            musicButton.image.sprite = musicOn;

            if (PlayerPrefs.GetInt("Music") == 0) {

                for (int i = 0; i < audio.Length; i++) {
                    audio[i].GetComponent<AudioSource>().volume = 1;
                }

            }

        }

    }
}
