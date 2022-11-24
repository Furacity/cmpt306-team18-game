using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perks : MonoBehaviour
{
    public GameObject upgradeEffect;
    // private Player player;
    // initialize variables for each ability

    public int perk;
    public int price;

    void Start()
    {

    }

    void Update()
    {

    }

    // sets a ui button to have a perk, fill description (purchasing at shop or selected as end-of-level bonus)
    private void perkSelection()
    {
        perk = Random.Range(0, 12);
        setPrice();
        switch (perk)
        {
            case 12:
                // Player Movement Speed+
                break;
            case 11:
                // LMB ability +bullet
                break;
            case 10:
                // LMB ability +damage
                break;
            case 9:
                // LMB ability +attack speed
                break;
            case 8:
                // RMB ability +damage
                break;
            case 7:
                // RMB ability lower cooldown
                break;
            case 6:
                // RMB ability uses + 1
                break;
            case 5:
                // Utility ability uses +1
                break;
            case 4:
                // Utility ability lower cooldown
                break;
            case 3:
                // Ultimate ability +damage
                break;
            case 2:
                // Ultimate ability +aoe
                break;
            case 1:
                // Ultimate abillity lower cooldown
                break;
            default:
                // Random ability improvement (lower cost)
                break;
        }
        displayEffect();
    }

    public void displayEffect()
    {
        GameObject effect = Instantiate(upgradeEffect, transform.position, transform.rotation);
        Destroy(effect, 1.0f);
    }

    public void setPrice()
    {
        price = Random.Range(5, 25); // * some scalar like # Level player is on
    }

    // checks that the player has enough money to buy an upgrade
    public void currencyCheck()
    {
        // if (currency < price), grays out the button and is unclickable, does not perform the upgrade
        // else if (currency >= price), upgrades, changes button to display "perk purchased", does the effect, then grays out the button and is unclickable
    }
}
