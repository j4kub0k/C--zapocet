using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script for the vision power up
/// </summary>
public class Vision_Power_Up : MonoBehaviour
{

    public Light flicker;

    /// <summary>
    /// After 5 seconds, the player's field of view is reset to 50 and the light flickers
    /// </summary>
    /// <param name="player"></param>
    /// <returns>IEnumerator</returns>
    IEnumerator Count(GameObject player)
    {
        yield return new WaitForSeconds(5);
        player.GetComponentInChildren<Text>().enabled = true;
        Camera.main.GetComponent<Camera>().fieldOfView = 50;
        flicker.GetComponent<flickering>().enabled = true;
        Destroy(gameObject);
    }

    /// <summary>
    /// On collision with the player, the player's field of view is increased for 5 seconds
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<Text>().enabled = true;
            collision.gameObject.GetComponentInChildren<Text>().text = "Vision";
            Camera.main.GetComponent<Camera>().fieldOfView = 100;
            flicker.GetComponent<flickering>().enabled = false;
            flicker.enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(Count(collision.gameObject));
            
        }
    }
}
