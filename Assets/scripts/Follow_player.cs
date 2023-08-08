using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Makes the camera follow the player
/// </summary>
public class Follow_player : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
    // Update is called once per frame
    void Update()
    {
        transform.position= new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        
    }
}
