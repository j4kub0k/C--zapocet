using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the enemy bullet and its collision with the player
/// </summary>
public class EnBulControl : MonoBehaviour
{
    public float speed;
    public AudioClip missSound;
    private void Die()
    {
        Destroy(gameObject);
    }

    /// <summary>
    /// Makes the bullet disappear when it collides with the player
    /// and plays the miss sound when it collides with anything else
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {

        float al=0;
        if (collision.gameObject.tag != "Player")
        {

            GetComponent<AudioSource>().clip = missSound;
            al = missSound.length;

        }
        GetComponent<AudioSource>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        GetComponent<Light>().enabled = false;
        Invoke("Die", al);

        //Destroy(gameObject);
    }
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * speed, ForceMode.Impulse);

    }

}
