using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuInteractables : MonoBehaviour
{
    public Button easy = null;
    public Button normal = null;
    public Button hard = null;
    public GameObject CanvasController = null;
    public Text valueText = null;
    public void OnDifficultyButtonPressed()
    {
        if(easy != null && normal != null && hard != null)
        {
            easy.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            normal.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            hard.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
            this.GetComponent<Image>().color = new Color(0.5424528f, 0.7658292f, 1.0f);
            if (this.CompareTag("easy"))
            {
                MainMenu.difficulty = 0;
            }
            if (this.CompareTag("normal"))
            {
                MainMenu.difficulty = 1;
            }
            if (this.CompareTag("hard"))
            {
                MainMenu.difficulty = 3;
            }
        }
    }

    public void OnMutatorsButtonPressed()
    {
        CanvasController.GetComponent<MainMenu>().ShowMutatorCanvas();
    }

    public void OnPlayButtonPressed()
    {
        CanvasController.GetComponent<MainMenu>().ShowGameSettingsCanvas();
    }

    public void OnMainMenuButtonPressed()
    {
        CanvasController.GetComponent<MainMenu>().HideGameSettingsCanvas();
    }

    public void OnMutatorConfirmButtonPressed()
    {
        CanvasController.GetComponent<MainMenu>().HideMutatorCanvas();
    }
    public void OnStartButtonPressed()
    {
        CanvasController.GetComponent<MainMenu>().StartGame();
    }

    public void OnDensitySliderChanged()
    {
        MainMenu.density = (int) this.GetComponent<Slider>().value;
        valueText.text = MainMenu.density * 10 + " % ";
    }

    public void OnSizeSliderChanged()
    {
        MainMenu.size = (int)this.GetComponent<Slider>().value;
        valueText.text = MainMenu.size + " x " + MainMenu.size;
    }

    public void OnExitToDesktopPressed()
    {
        Application.Quit();
    }
}
