using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAnimationHandler : MonoBehaviour
{
    public int option;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAnimationEnded()
    {
        if(option == 1)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        } else if(option == 2)
        {
            SceneManager.LoadScene("MainMenu");
        } else if(option == 3)
        {
            Application.Quit();
        }
    }

    public void OnReplayButtonPressed()
    {
        option = 1;
        animator.SetTrigger("FadeOut");
    }

    public void OnMainMenuButtonPressed()
    {
        option = 2;
        animator.SetTrigger("FadeOut");
    }

    public void OnQuitButtonPressed()
    {
        option = 3;
        animator.SetTrigger("FadeOut");
    }
}
