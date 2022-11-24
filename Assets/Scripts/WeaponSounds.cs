using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSounds : MonoBehaviour
{
    public AudioSource basicBlast;
    public AudioSource shotgunBlast;
    public AudioSource minigunBlast;
    public AudioSource rocketBlast;
    public AudioSource rocketExplode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBasicShot()
    {
        basicBlast.Play();
    }

    public void OnShotgunShot()
    {
        shotgunBlast.Play();
    }

    public void OnMinigunShot()
    {
        minigunBlast.Play();
    }

    public void OnRocketShot()
    {
        rocketBlast.Play();
    }

    public void OnRocketExplode()
    {
        rocketExplode.Play();
    }
}
