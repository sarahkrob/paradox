using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelchange : MonoBehaviour {

    Scene currentscene;
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) {
            currentscene = SceneManager.GetActiveScene();
            audio.Play();
            if (currentscene.name == "level_1")
                SceneManager.LoadScene("level_2");
            else if (currentscene.name == "level_2")
                SceneManager.LoadScene("level_3");
            else if (currentscene.name == "level_3")
                SceneManager.LoadScene("winscreen");
        }
    }
}
