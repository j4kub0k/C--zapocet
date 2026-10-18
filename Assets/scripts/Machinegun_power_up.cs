using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// changes the player's gun to machinegun on collision
/// </summary>
public class Machinegun_power_up : MonoBehaviour
{
    
    /// <summary>
    /// Gives the player the machine gun and consumes the pickup.
    /// </summary>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<controller>().SetGun(controller.gunType.machinegun);
            Destroy(gameObject);
        }
    }
}
