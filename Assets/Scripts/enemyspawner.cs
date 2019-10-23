using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject clone;
    public GameObject levelchange;
    private Animator animator;
    public int count = 0;
    public int levelcount;
    public int current_level;
    float random_x;
    Vector2 spawn_location;
    public float enemyspawnrate = 2.0f;
    float nextenemyspawn = 0.0f;
    public float clonespawnrate = 5.0f;
    float nextclonespawn;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        nextclonespawn = Random.Range(5.0f, 20.0f);
        nextenemyspawn = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (Time.timeSinceLevelLoad > nextenemyspawn) {
            nextenemyspawn = Time.timeSinceLevelLoad + enemyspawnrate;
            random_x = Random.Range(-2.2f, 2.2f);
            spawn_location = new Vector2(random_x, transform.position.y);
            Instantiate(enemy, spawn_location, Quaternion.identity);
        }
        if (current_level != 2 && Time.timeSinceLevelLoad > nextclonespawn)
        {
            nextclonespawn = Time.timeSinceLevelLoad + clonespawnrate;
            random_x = Random.Range(-2.2f, 2.2f);
            spawn_location = new Vector2(random_x, transform.position.y);
            Instantiate(clone, spawn_location, Quaternion.identity);
        }
    }
}
