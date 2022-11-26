using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGun : MonoBehaviour
{
    [SerializeField] private GameObject basicProjectile;
    [SerializeField] public float basicFireRate = 20.0f;
    [SerializeField] private float fireTime;
    [SerializeField] public float damage = 50.0f;
    [SerializeField] public int magazine = 50;
    public float spreadAngle;

    public Text cooldownText;
    // Start is called before the first frame update
    void Start()
    {
        cooldownText.text = "E";
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FireMinigun());
    }

    private IEnumerator SetCooldownText()
    {
        int i = 20;
        while (i > 0)
        {
            cooldownText.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
            i--;
        }
        cooldownText.text = "E";
    }

    private IEnumerator FireMinigun()
    {
        if (Input.GetKeyDown("e") && Time.time > fireTime)
        {
            fireTime = Time.time + basicFireRate;
            StartCoroutine(SetCooldownText());
            int i = 0;
            while (i < magazine)
            {
                GameObject bullet = Instantiate(basicProjectile, transform.position, transform.rotation);
                GetComponent<WeaponSounds>().OnMinigunShot();
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
