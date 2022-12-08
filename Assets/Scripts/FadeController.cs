using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FadeController : MonoBehaviour
{
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnFadeOutEnded()
    {
        if (CompareTag("menufader"))
        {
            controller.GetComponent<MainMenu>().OnFadeComplete();
        } else if (CompareTag("ingamefader"))
        {
            if(MainMenu.roundsUntilGrow == 0)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                controller.GetComponent<DungeonGenerator>().ReloadScene();
            }
            
        }
        
    }
}
