using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopMenuUI;
    // public GameObject upgradeEffect;

    private PlayerAbilities basicAttack;
    private Shotgun shotgun;
    private MiniGun minigun;
    private RocketLauncher rocket;

    public Text Price;
    public Text Description;

    bool shopInRange = false;
    bool shopOpenedOnce = false;
    bool purchased = false;

    public int perk = 0;
    public int price = 0;

    // Start is called before the first frame update
    void Start()
    {
        shopMenuUI.SetActive(false);
        basicAttack = GameObject.Find("Gun").GetComponent<PlayerAbilities>();
        shotgun = GameObject.Find("Gun").GetComponent<Shotgun>();
        minigun = GameObject.Find("Gun").GetComponent<MiniGun>();
        rocket = GameObject.Find("Gun").GetComponent<RocketLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (purchased == false)
        {
            if (shopInRange == true)
            {
                openShop();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    purchase();
                }
            }
        }
    }

    // check for player in collider range
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "shopcollider")
        {
            shopInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "shopcollider")
        {
            shopInRange = false;
            shopMenuUI.SetActive(false);
        }
    }

    private void openShop()
    {
        if (shopOpenedOnce == false)
        {  
            perk = Random.Range(0, 9);
            price = Random.Range(3, 6) * MainMenu.currentRound; 
            shopOpenedOnce = true;
        }
        //Description = gameObject.GetComponent<Text>();
        Price.text = "Price: " + price.ToString();
        perkDescription(perk);
        shopMenuUI.SetActive(true);
    }

    private void perkSelection(int perk)
    {
        switch (perk)
        {
            default:
                basicAttack.damage += 10.0f;
                break;
            case 1:
                basicAttack.basicFireRate = basicAttack.basicFireRate * 0.95f;
                break;
            case 2:
                shotgun.damage += 10.0f;
                break;
            case 3:
                shotgun.basicFireRate = shotgun.basicFireRate * 0.95f;
                break;
            case 4:
                shotgun.pelletCount += 3;
                break;
            case 5:
                minigun.damage += 10.0f;
                break;
            case 6:
                minigun.basicFireRate = minigun.basicFireRate * 0.95f;
                break;
            case 7:
                minigun.magazine += 5;
                break;
            case 8:
                rocket.damage += 100.0f;
                break;
            case 9:
                rocket.basicFireRate = rocket.basicFireRate * 0.95f;
                break;
        }
    }

    private void perkDescription(int perk)
    {
        switch (perk)
        {
            default:
                Description.text = "Increase basic attack damage by 10";
                break;
            case 1:
                Description.text = "Increase basic attack speed by 5%";
                break;
            case 2:
                Description.text = "Increase shotgun pellet damage by 10";
                break;
            case 3:
                Description.text = "Increase shotgun attack speed by 5%";
                break;
            case 4:
                Description.text = "Increase shotgun pellet count by 3";
                break;
            case 5:
                Description.text = "Increase minigun damage by 10";
                break;
            case 6:
                Description.text = "Increase minigun attack speed by 5%";
                break;
            case 7:
                Description.text = "Increase minigun bullet count by 5";
                break;
            case 8:
                Description.text = "Increase rocket launcher damage by 100";
                break;
            case 9:
                Description.text = "Increase rocket launcher attack speed by 5%";
                break;
        }        
    }

    public void displayEffect()
    {
        //GameObject effect = Instantiate(upgradeEffect, transform.position, transform.rotation);
        //Destroy(effect, 1.0f);
    }

    // checks that the player has enough money to buy an upgrade
    public void purchase()
    {
        if (MainMenu.currency >= price)
        {   
            shopMenuUI.SetActive(false);
            perkSelection(perk);
            GameManager.instance.subtractCoins(price);
            //displayEffect();
            purchased = true;
        }
        else
        {
            Debug.Log("Not enough coins.");
        }
    }
}
