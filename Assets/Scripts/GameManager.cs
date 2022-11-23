using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance = null;
    public GameObject player;
    public GameObject levelManager;
    public Text currencyText;


    // Start is called before the first frame update
    void Start()
    {
        
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

    

    public void SetCurrencyText()
    {
        currencyText.text = "Currency: " + MainMenu.currency.ToString();
    }
}
