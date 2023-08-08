using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This class is used to make the player move faster for a short period of time
/// </summary>
public class FasterMovement : MonoBehaviour
{
    private float speed = 0;
   
    /// <summary>
    /// returns the speed of the player to normal after 5 seconds
    /// and destroys the object
    /// </summary>
    IEnumerator Count(controller player)
    {
        yield return new WaitForSeconds(5);
        player.speed = speed;
        Destroy(gameObject);
    }

    /// <summary>
    /// On Collision with the player, the player's speed is doubled
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
       
            if (collision.gameObject.tag == "Player")
            {
                controller x = collision.gameObject.GetComponent<controller>();
                speed = x.speed;
                x.speed *= 2;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
                StartCoroutine(Count(x));
            }
    }
}
