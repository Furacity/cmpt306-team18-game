using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherMissile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2.0f;
    [SerializeField] private float moveSpeed = 100.0f;
    [SerializeField] private GameObject explosion;
    private bool hasPlayed = false;

    public GameObject shotEffect;
    public GameObject muzzleEffect;


    // Start is called before the first frame update
    void Start()
    {
        GameObject muzzle = Instantiate(muzzleEffect, transform.position, transform.rotation);
        Destroy(muzzle, 1.0f);
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayed)
        {
            Destroy(this.gameObject, .5f);
        }
        MoveMissile();
        Detonate();    
    }

    private void MoveMissile()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    private void Detonate()
    {
        if (Input.GetKeyDown("space") && !hasPlayed)
        {
            
            Instantiate(explosion, transform.position, transform.rotation);
            GetComponent<WeaponSounds>().OnRocketExplode();
            HideMissile();
            hasPlayed = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy" && !hasPlayed)
        {
            other.GetComponent<EnemyController>().TakeDamage(GameManager.instance.player.transform.GetChild(2).gameObject.GetComponent<RocketLauncher>().GetDamage());
            GetComponent<WeaponSounds>().OnRocketExplode();
            HideMissile();
            hasPlayed = true;
            //Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject effect = Instantiate(shotEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
        }
        else if (other.transform.tag == "wall" && !hasPlayed)
        {
            GetComponent<WeaponSounds>().OnRocketExplode();
            HideMissile();
            hasPlayed = true;
            //Destroy(this.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject effect = Instantiate(shotEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
        }
    }

    private void HideMissile()
    {
        Destroy(GetComponent<BoxCollider>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<TrailRenderer>());
    }
}