using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Heals the player on collision
/// </summary>
public class heal : MonoBehaviour
{
    /// <summary>
    /// Heals the player by one point and consumes the pickup.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<controller>().Heal(1);
            Destroy(gameObject);
        }
    }
}
