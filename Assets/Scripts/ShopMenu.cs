using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopMenuUI;

    bool shopInRange = false;
    bool shopMenuClosed = true;
    bool shopOpenedOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        shopMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shopInRange == true)
        {
            openShop();
        }
        if (shopMenuClosed == true)
        {
            shopInRange = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            shopInRange = true;
            shopMenuClosed = false;
        }
    }

    private void openShop()
    {
        if (shopOpenedOnce == false)
        {
            //randomly generate perks for each button
            shopOpenedOnce = true;
            shopMenuUI.SetActive(true);
        }

        else
        {
            shopMenuUI.SetActive(true);
        }
    }

    public void exitMenu()
    {
        shopMenuClosed = true;
        shopMenuUI.SetActive(false);
    }
}
