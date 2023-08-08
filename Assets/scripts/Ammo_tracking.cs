using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks amount of ammo player has and displays it on screen
/// </summary>
public class Ammo_tracking : MonoBehaviour
{
    private Transform text;
    private GameObject Player;
    void Start()
    {
        Player = GetComponentInParent<Pause>().player;
        text = GetComponent<Transform>();
    }

    void Update()
    {
        GetComponent<Text>().text = Player.GetComponent<controller>().GetAmmo().ToString();
        text.position= Camera.main.WorldToScreenPoint(Player.transform.position+Vector3.right*2);
    }
}
