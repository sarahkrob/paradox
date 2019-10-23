using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startgame : MonoBehaviour {

    public AudioSource audio;
    private AudioClip clip;
    // Use this for initialization
	void Start () {
        clip = audio.clip;
        transform.position = new Vector2(0, 0);
    }
	
	void OnMouseDown () {
        audio.Play();
        transform.position = Vector2.one * 9999f; // move the game object off screen while it finishes it's sound, then destroy it
        Destroy(gameObject, clip.length);
    }
}
