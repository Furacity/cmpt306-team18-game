using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    [SerializeField] private float lifeTime = 2.0f;
    [SerializeField] private float moveSpeed = 100.0f;

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
        MoveBasicProjectile();
    }

    private void MoveBasicProjectile()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            MainMenu.currency++;
            other.GetComponent<EnemyController>().TakeDamage(GameManager.instance.player.transform.GetChild(2).gameObject.GetComponent<PlayerAbilities>().GetDamage());
            GameObject effect = Instantiate(shotEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
        }
        else if (other.transform.tag == "wall")
        {
            GameObject effect = Instantiate(shotEffect, transform.position, transform.rotation);
            Destroy(effect, 1.0f);
            Destroy(this.gameObject);
        }
    }
}
