using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missile;
    [SerializeField] public float basicFireRate = 60.0f;
    [SerializeField] private float fireTime;
    [SerializeField] private bool allowFire;
    [SerializeField] public float damage = 500.0f;
    public Text cooldownText;
    
    // Start is called before the first frame update
    void Start()
    {
        cooldownText.text = "SPACE";
    }

    // Update is called once per frame
    void Update()
    {
        FireMissile();
    }

    private IEnumerator SetCooldownText()
    {
        int i = 60;
        while (i > 0)
        {
            cooldownText.text = i.ToString();
            yield return new WaitForSeconds(1.0f);
            i--;
        }
        cooldownText.text = "SPACE";
    }

    private void FireMissile()
    {
        if (Input.GetKeyDown("space") && Time.time > fireTime)
        {
            fireTime = Time.time + basicFireRate;
            StartCoroutine(SetCooldownText());
            Instantiate(missile, transform.position, transform.rotation);
            GetComponent<WeaponSounds>().OnRocketShot();
            fireTime = Time.time + basicFireRate;
        }
    }

    public float GetDamage()
    {
        return this.damage;
    }
}
