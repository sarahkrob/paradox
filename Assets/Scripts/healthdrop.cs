using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthdrop : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            var health = other.gameObject.GetComponent<playerhealth>();
            if (health != null)
            {
                health.Heal();
            }
        }
    }
}
