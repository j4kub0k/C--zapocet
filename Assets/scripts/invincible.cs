using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Makes the player invincible for 10 seconds
/// </summary>
public class invincible : MonoBehaviour
{
    /// <summary>
    /// makes itself invisible and uncollidable and after 10 seconds it destroys itself and makes the player vulnerable again
    /// </summary>
    IEnumerator CountDown(GameObject player,Text text)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(10);
        text.enabled = false;
        player.GetComponent<PlayerKill>().ChangeInvincible();
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Text text = collision.gameObject.GetComponent<Text>();
            text.enabled = true;
            text.text = "Invincible";
            GameObject Player = collision.gameObject;
            Player.GetComponent<PlayerKill>().ChangeInvincible();
            StartCoroutine(CountDown(Player,text));
        }
    }
}
