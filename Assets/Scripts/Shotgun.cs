using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private GameObject pellet;
    public int pelletCount;
    public float spreadAngle;
    [SerializeField] public float basicFireRate = 10.0f;
    [SerializeField] private float fireTime;
    [SerializeField] private bool allowFire;
    [SerializeField] public float damage = 50.0f;
    List<Quaternion> pellets;
    public float pelletFireVel = 1;

    public Text cooldownText;
    // Start is called before the first frame update

    void Awake()
    {
        cooldownText.text = "Q";
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

    private IEnumerator SetCooldownText()
    {
        int i = 10;
        while (i > 0)
        {
            cooldownText.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
            i--;
        }
        cooldownText.text = "Q";
        
    }
    private void ShotgunAttack()
    {
        if (Input.GetKeyDown("q") && Time.time > fireTime)
        {
            for (int i = 0; i < pelletCount; i++)
            {
                GameObject p = Instantiate(pellet, transform.position, transform.rotation);
                GetComponent<WeaponSounds>().OnShotgunShot();
                p.transform.Rotate(Vector3.up * Random.Range(-spreadAngle / 2, spreadAngle / 2));
                p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);
                
            }
            fireTime = Time.time + basicFireRate;
            StartCoroutine(SetCooldownText());
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
