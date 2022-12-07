using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    static public float difficulty { get; set; }
    static public int density { get; set; }
    static public int size { get; set; }
    static public int currentRound { get; set; }

    static public int roundsUntilGrow { get; set; }

    static public int currency { get; set; }

    public GameObject mutatorCanvasHolder;
    public GameObject gameSettingsCanvasHolder;
    public GameObject mainMenuCanvasHolder;
    public GameObject settingsPanel;
    public Canvas mutators;
    public Canvas play;
    public Button normal;
    public GameObject sceneManager;

    public GameObject forwardAudio;
    public GameObject backAudio;
    public GameObject sliderAudio;
    public GameObject fadepanel;

    public Animator animator;

    private bool mutator = false;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 0.9f;
        density = 2;
        size = 10;
        currentRound = 1;
        currency = 0;
        roundsUntilGrow = -1;
        mutatorCanvasHolder.SetActive(false);
        gameSettingsCanvasHolder.SetActive(false);
        normal.GetComponent<Image>().color = new Color(0.5424528f, 0.7658292f, 1.0f);
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButtonForward()
    {
        forwardAudio.GetComponent<AudioSource>().Play();
    }

    public void PlayButtonBack()
    {
        backAudio.GetComponent<AudioSource>().Play();
    }
    public void PlaySliderChange()
    {
        sliderAudio.GetComponent<AudioSource>().Play();
    }

    public void HideMutatorCanvas()
    {
        mutatorCanvasHolder.SetActive(false);
    }

    public void ShowMutatorCanvas()
    {
        mutatorCanvasHolder.SetActive(true);
    }

    public void HideGameSettingsCanvas()
    {
        mutator = false;
        gameSettingsCanvasHolder.SetActive(false);
    }

    public void HideMainMenuCanvas()
    {
        mainMenuCanvasHolder.SetActive(false);
    }

    public void ShowMainMenuCanvas()
    {
        mainMenuCanvasHolder.SetActive(true);
    }

    public void ShowGameSettingsCanvas()
    {
        mutator = true;
        gameSettingsCanvasHolder.SetActive(true);
    }

    public void ShowSettingsCanvas()
    {
        settingsPanel.SetActive(true);
    }

    public void StartGame()
    {
        if (!mutator)
        {
            difficulty = 1;
            density = 2;
            size = 3;
            roundsUntilGrow = 5;
        }
        animator.SetTrigger("FadeOut");
        
    }

    public void OnFadeComplete()
    {
        sceneManager.GetComponent<LevelManager>().ChangeScene("PRG SCENE");
    }

}
