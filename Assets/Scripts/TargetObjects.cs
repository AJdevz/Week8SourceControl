using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public float health;

    void Start()
    {
        // Set a random health value between 50 and 150 (you can adjust these values)
        health = Random.Range(10f, 50f);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            // Optionally, you could play a destruction animation here before destroying
            Destroy(gameObject);
        }
    }
}


