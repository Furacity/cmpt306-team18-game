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

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 1;
        density = 2;
        size = 10;
        mutatorCanvasHolder.SetActive(false);
        gameSettingsCanvasHolder.SetActive(false);
        normal.GetComponent<Image>().color = new Color(0.5424528f, 0.7658292f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDifficulty()
    {

    }

    public void UpdateDensity()
    {
        
    }

    public void UpdateSize()
    {

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
        sceneManager.GetComponent<LevelManager>().ChangeScene("PRG SCENE");
    }

}
