using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour

{

    [SerializeField] private float health = 100.0f;
    public GameObject deathEffect;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
        }
    }
}


