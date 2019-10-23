using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class instructionscript : MonoBehaviour {


    public AudioSource audio;
    // Use this for initialization
    void Start () {

    }

    void OnMouseDown()
    {
        audio.Play();
        SceneManager.LoadScene("level_1");
    }
}
