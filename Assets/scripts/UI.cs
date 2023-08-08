using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keeps track of the player's health and updates the UI
/// </summary>
public class UI : MonoBehaviour
{
    private Transform text;
    private GameObject Player;   
    void Start()
    {
        Player = GetComponentInParent<Pause>().player;
        text = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = Player.GetComponentInParent<PlayerKill>().GetHealth().ToString();
        text.position= Camera.main.WorldToScreenPoint(Player.transform.position+Vector3.left);//makes it follow the player
    }
}
