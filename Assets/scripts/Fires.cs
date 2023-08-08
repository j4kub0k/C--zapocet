using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fires : MonoBehaviour
{

    public Light _light;
    public GameObject bullet;
    public GameObject firepoint;
  
    /// <summary>
    ///  turn off the muzzle flash
    /// </summary>
    void LightOff()
    {
        _light.enabled = false;
        firepoint.SetActive(false);
        
    }

    /// <summary>
    /// Fire the bullet and turn on the muzzle flash.
    /// Sets the damage of the bullet if the parent is the player
    /// </summary>
    /// <param name="damage"></param>
        public void fire( int damage, AudioClip audioClip)
        {
            Debug.Log("fire");
            GameObject spawned = Instantiate(bullet, firepoint.transform.position, transform.rotation);
            _light.enabled = true;
        if (transform.parent.gameObject.tag == "Player")
            {
                spawned.GetComponent<bullletControl>().SetDamage(damage);
            }
            firepoint.SetActive(true);
            if(audioClip != null)
                GetComponent<AudioSource>().PlayOneShot(audioClip);
            else
                GetComponent<AudioSource>().Play();
            Invoke("LightOff", 0.15f);
        }
      
}
