using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritemovement : MonoBehaviour
{

    public float speed;
    private SpriteRenderer srender;

    // Use this for initialization
    void Start()
    {
        srender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
        }
        if (Input.GetKeyDown("down"))
        {
        }
        if (Input.GetKeyDown("left"))
        {
            srender.flipX = true;
        }
        if (Input.GetKeyDown("right"))
        {
            srender.flipX = false;
        }
    }
}
