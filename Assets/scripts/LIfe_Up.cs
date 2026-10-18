using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// increases the player's max health by 1
/// </summary>
public class LIfe_Up : MonoBehaviour
{
    /// <summary>
    /// Raises the player's max health and fully heals him.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            controller x = collision.gameObject.GetComponent<controller>();
            x.MaxHealth += 1;
            x.RestoreHealth();
            Destroy(gameObject);
        }
    }
}
