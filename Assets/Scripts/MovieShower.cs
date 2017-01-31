using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MovieTexture))]
[RequireComponent(typeof(AudioSource))]

public class MovieShower : MonoBehaviour {

    public string nextScene;

    private MovieTexture movie;
    private AudioSource sound;
   

	// Use this for initialization
	void Start () {
        movie = GetComponent<Renderer>().material.mainTexture as MovieTexture;
        sound = GetComponent<AudioSource>();
        sound.clip = movie.audioClip;

        sound.Play();
        movie.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return) || (!movie.isPlaying || !sound.isPlaying))
            SceneManager.LoadScene(nextScene);
	}
}
