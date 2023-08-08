using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Heals the player on collision
/// </summary>
public class heal : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<controller>().Heal(1);
            Destroy(gameObject);
        }
    }
}
