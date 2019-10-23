using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour {

    Transform Player;
    private GameObject spawner;
    private GameObject levelchange;
    public GameObject healthdrop;
    private Animator animator;
    private AudioSource audio;
    enemyspawner spawnerscript;
    float range;
    public float move_speed = 1.0f;
    public float min_dist = 1.0f;
    public float drop_rate = 0.01f;
    private Vector2 lastpos;

    // Use this for initialization
    void Start () {
        Collider2D[] colliders = GameObject.FindGameObjectWithTag("BackgroundColliders").GetComponents<Collider2D>();
        foreach (Collider2D c in colliders)
        {
            Physics2D.IgnoreCollision(c, GetComponent<Collider2D>());
        }
        Player = GameObject.FindWithTag("Player").transform;
        spawner = GameObject.FindWithTag("Spawner");
        spawnerscript = spawner.GetComponent<enemyspawner>();
        levelchange = spawnerscript.levelchange;
        animator = GetComponent<Animator>();
        animator.SetLayerWeight(spawnerscript.current_level, 1);
        audio = GetComponent<AudioSource>();
    }

	// Update is called once per frame
    void Update () {
        lastpos = transform.position;
        range = Vector2.Distance(transform.position, Player.position);
        if (range >= min_dist) {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, move_speed * Time.deltaTime);
        }
        Vector2 poschange = new Vector2(lastpos.x - transform.position.x, lastpos.y - transform.position.y);
        Animate(poschange);
    }

    void Animate(Vector2 direction) {
        animator.SetFloat("y", direction.y);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            var health = other.gameObject.GetComponent<playerhealth>();
            if (health != null)
            {
                health.Damage();
            }
        }
        if (other.gameObject.CompareTag("Bullet"))
        {

            audio.Play();
            Destroy(gameObject);
            spawnerscript.count += 1;
            if (spawnerscript.count == spawnerscript.levelcount) {
                Instantiate(levelchange, gameObject.transform.position, Quaternion.identity);
            }
            if (Random.Range(0.0f, 1.0f) <= drop_rate) {
                Instantiate(healthdrop, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}