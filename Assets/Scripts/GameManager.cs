using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int coins = 0;
    private int kills = 0;
    public static GameManager instance = null;
    public GameObject player;
    public GameObject levelManager;
    public Text currencyText;
    public Text deathCurrencyText;
    public Text killsText;
    public float difficulty;
    [SerializeField] private float scaleTimer = 0f;
    [SerializeField] private float scaleThresh = 5f;
    [SerializeField] private float difficultyScalar = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(2))
        {
            difficulty = MainMenu.difficulty;
            currencyText.text = "Currency: " + MainMenu.currency;
            deathCurrencyText.text = "Currency: " + MainMenu.currency;
            killsText.text = "Kills: " + kills;
        }
        else
        {
            difficulty = MainMenu.difficulty;
            currencyText.text = "";
            deathCurrencyText.text = "";
            killsText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        scaleTimer += Time.deltaTime;
        if(scaleTimer >=  scaleThresh){
            difficulty += difficultyScalar;
            scaleTimer = 0f;
        }
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
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(2))
        {
            MainMenu.currency += value;
            currencyText.text = "Currency: " + MainMenu.currency;
            deathCurrencyText.text = "Currency: " + MainMenu.currency;
        }
        else
        {
            MainMenu.currency += value;
            currencyText.text = "";
            deathCurrencyText.text = "";
        }
    }

    public void subtractCoins(int value)
    {
        if (SceneManager.GetActiveScene() != SceneManager.GetSceneByBuildIndex(2))
        {
            MainMenu.currency -= value;
            currencyText.text = "Currency: " + MainMenu.currency;
            deathCurrencyText.text = "Currency: " + MainMenu.currency;
        }
        else
        {
            MainMenu.currency -= value;
            currencyText.text = "";
            deathCurrencyText.text = "";
        }
    }
    public void addKill(){
        kills++;
        killsText.text = "Kills: " + kills;
    }
    public int getKills(){
        return kills;
    }
}
