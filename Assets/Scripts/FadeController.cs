using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            controller.GetComponent<DungeonGenerator>().ReloadScene();
        }
        
    }
}
