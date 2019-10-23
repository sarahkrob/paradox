using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershoot : MonoBehaviour {

    public Rigidbody2D bullet;
    public float cooldownTime = 0.0f;
    private float attackrate = 0.2f;
    public float movespeed = 10.0f;
    private bool shooting = false;
    private Animator animator;
    private PlayerMovement script;
    private AudioSource audio;

    void Start()
    {
        animator = GetComponent<Animator>();
        script = gameObject.GetComponent<PlayerMovement>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
        if (Time.time >= cooldownTime) {
            if (Input.GetKeyDown("space")) {
                audio.Play();
                Fire();
            }
        }
        if (shooting == false) {
            animator.SetLayerWeight((script.current_level + 1), 0);
        }
    }

    void Fire() {
        Rigidbody2D newbullet = Instantiate(bullet, transform.position, Quaternion.identity) as Rigidbody2D;
        animator.SetLayerWeight((script.current_level + 1), 1);
        if (script.direction == 1) {
            newbullet.velocity = transform.up * movespeed;
        }
        if (script.direction == 2)
        {
            newbullet.velocity = transform.right * movespeed;
        }
        if (script.direction == 3)
        {
            newbullet.velocity = transform.up * movespeed * -1.0f;
        }
        if (script.direction == 4)
        {
            newbullet.velocity = transform.right * movespeed * -1.0f;
        }
        shooting = true;
        StartCoroutine(Animate(newbullet.velocity));
        Physics2D.IgnoreCollision(newbullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        cooldownTime = Time.time + attackrate;
    }

    private IEnumerator Animate(Vector2 shoot)
    {
        animator.SetFloat("x", shoot.x);
        animator.SetFloat("y", shoot.y);
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(1).length);
        shooting = false;
    }
}
