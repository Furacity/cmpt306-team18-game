using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCover : MonoBehaviour
{
    public GameObject cover;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cover);
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectivesUI.chargingComplete == true)
        {
            Debug.Log("charging complete");
            Destroy(cover);
        }
    }
}
