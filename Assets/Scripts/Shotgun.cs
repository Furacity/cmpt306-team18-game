using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private GameObject pellet;
    public int pelletCount;
    public float spreadAngle;
    [SerializeField] private float basicFireRate = 0.5f;
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
            int i = 0;
            foreach(Quaternion quat in pellets.ToArray())
            {
                pellets[i] = Random.rotation;
                GameObject p = Instantiate(pellet, transform.position, transform.rotation);
                p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
                p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
                i++;
                fireTime = Time.time + basicFireRate;
            }
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
