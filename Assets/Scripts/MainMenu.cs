using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    static public int difficulty { get; set; }
    static public int density { get; set; }
    static public int size { get; set; }

    public GameObject mutatorCanvasHolder;
    public GameObject gameSettingsCanvasHolder;
    public Canvas mutators;
    public Canvas play;
    public Button normal;
    public GameObject sceneManager;

    public GameObject forwardAudio;
    public GameObject backAudio;
    public GameObject sliderAudio;
    public GameObject fadepanel;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 1;
        density = 2;
        size = 10;
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
        gameSettingsCanvasHolder.SetActive(false);
    }

    public void ShowGameSettingsCanvas()
    {
        gameSettingsCanvasHolder.SetActive(true);
    }

    public void StartGame()
    {
        animator.SetTrigger("FadeOut");
        
    }

    public void OnFadeComplete()
    {
        sceneManager.GetComponent<LevelManager>().ChangeScene("PRG SCENE");
    }

}
