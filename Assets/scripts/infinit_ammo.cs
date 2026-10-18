using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Makes the player's ammo infinit for 10 seconds
/// </summary>
public class infinit_ammo : MonoBehaviour
{
    /// <summary>
    /// Hides the pickup and turns infinite ammo off again after 10 seconds.
    /// </summary>
    IEnumerator CountDown(GameObject player, Text text)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10);
        text.enabled = false;
        player.GetComponent<controller>().ChangeInfinit();
        Destroy(gameObject);
    }
    /// <summary>
    /// Turns on infinite ammo for the player.
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Text text = collision.gameObject.GetComponent<Text>();
            text.enabled = true;
            text.text = "Infinit Ammo";
            GameObject Player = collision.gameObject;
            collision.gameObject.GetComponent<controller>().ChangeInfinit();
            StartCoroutine(CountDown(Player, text));
        }
    }
}
