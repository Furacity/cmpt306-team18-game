using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Arena : MonoBehaviour
{
    public GameObject forceField;
    public Text roundText;
    // Start is called before the first frame update
    void Start()
    {
        forceField.SetActive(false);
        roundText.text = "The Zucc senses your arrival";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other is CapsuleCollider)
        {
            Destroy(GetComponent<Rigidbody>());
            forceField.SetActive(true);
        }
    }
}
