using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// changes the player's gun to shotgun on collision
/// </summary>
public class shotgun_power_up : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<controller>().SetGun(controller.gunType.shotgun);
            Destroy(gameObject);
        }
    }

}
