using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider SFXSlider;
    public Slider UISlider;
    public Text masterLabel;
    public Text musicLabel;
    public Text SFXLabel;
    public Text UILabel;
    public AudioSource buttonForward;
    public AudioSource buttonBack;
    public AudioSource sliderChange;
    private float masterVol;
    private float musicVol;
    private float SFXVol;
    private float UIVol;
    private AudioMixerGroup[] groups;
    public GameObject mainMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        groups = mixer.FindMatchingGroups(null);
        GetMixerValues();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMasterSliderChange()
    {
        masterVol = masterSlider.value;
        masterLabel.text = Mathf.Floor(masterSlider.value * 100) + "%";
        sliderChange.Play();
    }

    public void OnMusicSliderChange()
    {
        musicVol = musicSlider.value;
        musicLabel.text = Mathf.Floor(musicSlider.value * 100) + "%";
        sliderChange.Play();
    }
    public void OnSFXSliderChange()
    {
        SFXVol = SFXSlider.value;
        SFXLabel.text = Mathf.Floor(SFXSlider.value * 100) + "%";
        sliderChange.Play();
    }
    public void OnUISliderChange()
    {
        UIVol = UISlider.value;
        UILabel.text = Mathf.Floor(UISlider.value * 100) + "%";
        sliderChange.Play();
    }

    public void OnConfirmPressed()
    {
        groups[0].audioMixer.SetFloat("MasterVol", Mathf.Log10(masterVol) * 20);
        groups[1].audioMixer.SetFloat("MusicVol", Mathf.Log10(musicVol) * 20);
        groups[2].audioMixer.SetFloat("SFXVol", Mathf.Log10(SFXVol) * 20);
        groups[3].audioMixer.SetFloat("UIVol", Mathf.Log10(UIVol) * 20);
        GetMixerValues();
        buttonForward.Play();
    }

    public void OnCancelPressed()
    {
        GetMixerValues();
        buttonBack.Play();
        gameObject.SetActive(false);
        mainMenuCanvas.SetActive(true);

    }

    public void GetMixerValues()
    {
        groups[0].audioMixer.GetFloat("MasterVol", out masterVol);
        masterVol = Mathf.Pow(10, masterVol / 20);
        masterSlider.value = masterVol;
        masterLabel.text = Mathf.Floor(masterSlider.value * 100) + "%";
        groups[1].audioMixer.GetFloat("MusicVol", out musicVol);
        musicVol = Mathf.Pow(10, musicVol / 20);
        musicSlider.value = musicVol;
        musicLabel.text = Mathf.Floor(musicSlider.value * 100) + "%";
        groups[2].audioMixer.GetFloat("SFXVol", out SFXVol);
        SFXVol = Mathf.Pow(10, SFXVol / 20);
        SFXSlider.value = SFXVol;
        SFXLabel.text = Mathf.Floor(SFXSlider.value * 100) + "%";
        groups[3].audioMixer.GetFloat("UIVol", out UIVol);
        UIVol = Mathf.Pow(10, UIVol / 20);
        UISlider.value = UIVol;
        UILabel.text = Mathf.Floor(UISlider.value * 100) + "%";
    }
}
