using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int coins = 0;
    public static GameManager instance = null;
    public GameObject player;
    public GameObject levelManager;
    public Text currencyText;
    public Text deathCurrencyText;

    // Start is called before the first frame update
    void Start()
    {
        currencyText.text = "Currency: " + MainMenu.currency;
        deathCurrencyText.text = "Currency: " + MainMenu.currency;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void addCoins(int value)
    {
        MainMenu.currency += value;
        currencyText.text = "Currency: " + MainMenu.currency;
        deathCurrencyText.text = "Currency: " + MainMenu.currency;
    }
}
