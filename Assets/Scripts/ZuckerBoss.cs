using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZuckerBoss : MonoBehaviour
{
    //Default Enemy stats
    [SerializeField] private float moveSpeed = 15.0f;
    [SerializeField] private float maxHealth = 20000.0f;
    [SerializeField] private float health = 20000.0f;

    [SerializeField] private bool ranged = false;
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private float projectileFireRate = 0.15f;
    [SerializeField] private float projectileRange = 50f;

    private float rangedFireTime;


    [SerializeField] private float contactDamageToPlayer = 50.0f;
    [SerializeField] private float contactDamageRate = 0.2f;
    [SerializeField] private float contactDamageTime;
    [SerializeField] private float seekDistance = 20f;

    [SerializeField] Rigidbody rb;
    [SerializeField] private Renderer[] healthRenderers = new Renderer[0];
    public float currentDissolve = -1.0f;
    private float endDissolve = -1.0f;
    private bool isDead = false;
    public GameObject playerMesh;

    public GameObject deathEffect;

    public GameObject[] itemDrop = new GameObject[4];

    public AudioSource deathNoise;
    private bool shootingPhase = false;
    public float shootAttackTime = 10f;
    private float shootingPhaseDuration;
    private float shootPhaseTimer;
    public Image healthbar;
    public Image depletebar;

    private bool invincible = false;
    private bool phase2 = false;

    private void Start()
    {
        shootPhaseTimer = Random.Range(8, 12) + Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthbar.fillAmount < depletebar.fillAmount)
        {
            depletebar.fillAmount = Mathf.Lerp(depletebar.fillAmount, healthbar.fillAmount, 2.0f * Time.deltaTime);
        }
        else
        {
            depletebar.fillAmount = healthbar.fillAmount;
        }
        if (Time.time > shootPhaseTimer && !shootingPhase)
        {
            shootingPhase = true;
            invincible = true;
            ranged = true;
            shootingPhaseDuration = Time.time + shootAttackTime;
            healthbar.color = Color.blue;
        }
        if (Time.time > shootingPhaseDuration && shootingPhase)
        {
            shootingPhase = false;
            invincible = false;
            ranged = false;
            shootPhaseTimer = Time.time + Random.Range(8, 12);
            healthbar.color = Color.red;
        }
        if (GameManager.instance.player.GetComponent<PlayerMovement>().dead)
        {
            Destroy(this.gameObject);
        }

        if (ranged)
        {
            if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < projectileRange)
            {
                RangedAttack();
            }
        }

            Movement();
    }


    private void Movement()
    {
        if (GameManager.instance.player)
        { //null reference check
            transform.LookAt(GameManager.instance.player.transform.position); //Look at the player

            if (Vector3.Distance(transform.position, GameManager.instance.player.transform.position) < seekDistance && !shootingPhase)
            {
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
            }
        }

    }


    private void RangedAttack()
    {
        if (Time.time > rangedFireTime)
        {
            GameObject projectile = Instantiate(enemyProjectile, transform.position, transform.rotation);
            rangedFireTime = Time.time + projectileFireRate;
        }
    }


    public void TakeDamage(float damage)
    {
        if (!invincible) { 
            health -= damage;
            healthbar.fillAmount = Mathf.Clamp(health / maxHealth, 0.0f, 1.0f);
            if (health <= 0)
            {
                deathNoise.Play();
                Destroy(this.gameObject);

            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && Time.time > contactDamageTime && other is CapsuleCollider && !isDead)

        {
            other.transform.GetComponent<PlayerDamage>().TakeDamage(contactDamageToPlayer);
            contactDamageTime = Time.time + contactDamageRate;
        }

    }
}