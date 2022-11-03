using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private float lifeTime = 5.0f;
    [SerializeField] private float rotateSpeed = 270.0f;
    [SerializeField] private float speed = 10.0f;

    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void OnTriggerStay(Collider other){

        if(other is SphereCollider && other.transform.tag == "Player"){
            transform.position = Vector3.MoveTowards(this.transform.position, other.transform.position, speed * Time.deltaTime);
        }
        
        if(other.transform.tag == "Player" && other is CapsuleCollider){
            //GameManager.instance.AddPoints(value); //some sort of increment goes here
            Destroy(this.gameObject);
        } 
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
