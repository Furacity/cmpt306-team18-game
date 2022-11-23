using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missile;
    [SerializeField] private float basicFireRate = 0.5f;
    [SerializeField] private float fireTime;
    [SerializeField] private bool allowFire;
    [SerializeField] public float damage = 500.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        FireMissile();
    }

    private void FireMissile()
    {
        if (Input.GetKeyDown("space") && Time.time > fireTime)
        {
            Instantiate(missile, transform.position, transform.rotation);
            fireTime = Time.time + basicFireRate;
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
