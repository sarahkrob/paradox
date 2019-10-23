using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    private SpriteRenderer srender;
    public int direction = 3;
    public int current_level;
    private Animator animator;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        srender = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        direction = 3;
    }
	
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
        Animate(rb2d.velocity);
        if (Input.GetKeyDown("up"))
        {
            direction = 1;
        }
        if (Input.GetKeyDown("down"))
        {
            direction = 3;
        }
        if (Input.GetKeyDown("left"))
        {
            direction = 4;
        }
        if (Input.GetKeyDown("right"))
        {
            direction = 2;
        }
    }

    void Animate(Vector2 direct) {
        animator.SetFloat("x", direct.x);
        animator.SetFloat("y", direct.y);
    }
}
