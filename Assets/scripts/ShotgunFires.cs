using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// script for shotgun firing
/// </summary>
public class ShotgunFires : MonoBehaviour
{
    public AudioClip shotgunSound;
    public Light _light;
    public GameObject bullet;
    public GameObject firepoint;


    /// <summary>
    /// turn off the muzzle flash
    /// </summary>
    void LightOff()
    {
        _light.enabled = false;
        firepoint.SetActive(false);

    }
    /// <summary>
    /// Instantiates 3 bullets in a cone shape and rotates 2 of them to the left and right by 10 degrees 
    /// Sets the damage of the bullets to the damage parameter
    /// Makes the muzzle flash visible and plays the shotgun sound
    /// </summary>
    /// <param name="damage"></param>
    public void fire(int damage)
    {
        GameObject spawned = Instantiate(bullet, firepoint.transform.position, transform.rotation);
        GameObject spawned1 = Instantiate(bullet, firepoint.transform.position, transform.rotation);
        GameObject spawned2 = Instantiate(bullet, firepoint.transform.position, transform.rotation);
        spawned1.transform.Rotate(0, 10, 0);
        spawned2.transform.Rotate(0, -10, 0);
        spawned2.GetComponent<bullletControl>().SetDamage(damage);
        spawned1.GetComponent<bullletControl>().SetDamage(damage);
        spawned.GetComponent<bullletControl>().SetDamage(damage);
        _light.enabled = true;
        firepoint.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(shotgunSound);
        Invoke("LightOff", 0.15f);
    }

}
