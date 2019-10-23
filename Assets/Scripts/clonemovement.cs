using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clonemovement : MonoBehaviour {

    Transform Player;
    private Animator animator;
    private AudioSource audio;
    private enemyspawner spawnerscript;
    float range;
    public float move_speed = 1.0f;
    public float max_dist = 1.0f;
    public float min_dist = 1.0f;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        GameObject spawner = GameObject.FindWithTag("Spawner");
        spawnerscript = spawner.GetComponent<enemyspawner>();
        animator = GetComponent<Animator>();
        animator.SetLayerWeight(spawnerscript.current_level, 1);
        Collider2D[] colliders = GameObject.FindGameObjectWithTag("BackgroundColliders").GetComponents<Collider2D>();
        foreach (Collider2D c in colliders)
        {
            Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
        }
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, Player.position);
        if (range >= min_dist)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, move_speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (spawnerscript.current_level == 2) {
                SceneManager.LoadScene("winscreen");
            }
            gameObject.SetActive(false);

        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            audio.Play();
            transform.position = Vector2.one * 9999f; // move the game object off screen while it finishes it's sound, then destroy it
            Destroy(gameObject, audio.clip.length);
            var health = Player.GetComponent<playerhealth>();
            if (health != null)
            {
                health.Damage();
            }
        }
    }
}
