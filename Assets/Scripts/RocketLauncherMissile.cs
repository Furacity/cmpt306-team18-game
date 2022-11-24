using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherMissile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2.0f;
    [SerializeField] private float moveSpeed = 100.0f;
    [SerializeField] private GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMissile();
        Detonate();    
    }

    private void MoveMissile()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void Detonate()
    {
        if (Input.GetKeyDown("space"))
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().TakeDamage(GameManager.instance.player.transform.GetChild(2).gameObject.GetComponent<RocketLauncher>().GetDamage());
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
        else if (other.transform.tag == "wall")
        {
            Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}