using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour {

    public const int maxhealth = 5;
    static int health = maxhealth;
    public Text healthtext;
    private AudioSource audio;
    public AudioClip clipdamage;
    public AudioClip clipheal;

    public void Start()
    {
        PlayerMovement playerscript = GetComponent<PlayerMovement>();
        if (playerscript.current_level == 0)
        {
            health = maxhealth;
        }
        healthtext.text = "LIVES: " + health.ToString();
        audio = GetComponent<AudioSource>();
    }

    public void Damage() {
        health -= 1;
        healthtext.text = "LIVES: " + health.ToString();
        audio.PlayOneShot(clipdamage);
        if (health <= 0) {
            health = 0;
            SceneManager.LoadScene("gameover");
        }
    }

    public void Heal() {
        if (health < maxhealth) {
            audio.PlayOneShot(clipheal);
            health += 1;
            healthtext.text = "LIVES: " + health.ToString();
        }
    }
}
