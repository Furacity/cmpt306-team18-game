using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGun : MonoBehaviour
{
    [SerializeField] private GameObject basicProjectile;
    [SerializeField] private float basicFireRate = 0.5f;
    [SerializeField] private float fireTime;
    [SerializeField] public float damage = 50.0f;
    [SerializeField] public int magazine = 50;
    public float spreadAngle;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FireMinigun());
    }

    private IEnumerator FireMinigun()
    {
        if (Input.GetKeyDown("e"))
        {
            int i = 0;
            while (i < magazine)
            {
                GameObject bullet = Instantiate(basicProjectile, transform.position, transform.rotation);
                bullet.transform.Rotate(Vector3.up * Random.Range(-spreadAngle, spreadAngle));
                yield return new WaitForSeconds(0.1f);
                i++;
            }
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
