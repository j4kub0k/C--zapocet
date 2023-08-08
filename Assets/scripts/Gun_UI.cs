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
    void Start()
    {
        Player = GetComponentInParent<Pause>().player;
        text = this.GetComponent<Transform>();
    }

    void Update()
    {
        GetComponent<Text>().text = Player.GetComponent<controller>().GetCurrentGun().ToString();
        text.position = Camera.main.WorldToScreenPoint(Player.transform.position+Vector3.back);
    }
}
