using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Shows the current gun the player has
/// </summary>
public class Gun_UI : MonoBehaviour
{
    private Transform text;
    private GameObject Player;
    /// <summary>
    /// Caches the player reference and the text transform.
    /// </summary>
    void Start()
    {
        Player = GetComponentInParent<Pause>().player;
        text = this.GetComponent<Transform>();
    }

    /// <summary>
    /// Shows the current gun name and keeps the label next to the player.
    /// </summary>
    void Update()
    {
        GetComponent<Text>().text = Player.GetComponent<controller>().GetCurrentGun().ToString();
        text.position = Camera.main.WorldToScreenPoint(Player.transform.position+Vector3.back);
    }
}
