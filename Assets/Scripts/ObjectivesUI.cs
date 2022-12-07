using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesUI : MonoBehaviour
{
    public Text currentObjectiveText;
    public Text chargePortalText;
    public int time = 0;
    public bool portalFound = false;
    public bool startCharging = false;
    public bool currentlyCharging = false;
    static public bool chargingComplete { get; set; }

    private void Awake()
    {
        chargingComplete = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentObjectiveText.text = "find the portal";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startCharging == false && Input.GetKeyDown("f") && portalFound == true)
        {
            chargePortalText.text = "";
            startCharging = true;
        }
        if (startCharging == true)
        {
            StartCoroutine(ChargePortal());
            startCharging = false;
            currentlyCharging = true;
        }
    }

    public void FoundPortalText()
    {
        currentObjectiveText.text = "charge the portal";
    }

    public IEnumerator ChargePortal()
    {
        while (time < 100)
        {
            currentObjectiveText.text = "Charging Portal: %" + time.ToString();
            yield return new WaitForSeconds(0.5f);
            time++;
            
        }
        currentObjectiveText.text = "Portal charged: Enter Portal";
        chargingComplete = true;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "Portal" && currentlyCharging == false)
        {
            FoundPortalText();
            chargePortalText.text = "Press 'F' to charge the portal";
            portalFound = true;
        }
    }
}
