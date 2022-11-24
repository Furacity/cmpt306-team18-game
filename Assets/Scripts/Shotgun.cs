using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private GameObject pellet;
    public int pelletCount;
    public float spreadAngle;
    [SerializeField] public float basicFireRate = 0.5f;
    [SerializeField] private float fireTime;
    [SerializeField] private bool allowFire;
    [SerializeField] public float damage = 50.0f;
    List<Quaternion> pellets;
    public float pelletFireVel = 1;
    // Start is called before the first frame update
    void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for(int i = 0; i < pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShotgunAttack();
    }

    private void ShotgunAttack()
    {
        if (Input.GetKeyDown("q") && Time.time > fireTime)
        {
            for (int i = 0; i < pelletCount; i++)
            {
                GameObject p = Instantiate(pellet, transform.position, transform.rotation);
                p.transform.Rotate(Vector3.up * Random.Range(-spreadAngle / 2, spreadAngle / 2));
                p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
                fireTime = Time.time + basicFireRate;
            }
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
