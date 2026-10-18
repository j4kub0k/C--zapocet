using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks amount of ammo player has and displays it on screen
/// </summary>
public class Ammo_tracking : MonoBehaviour
{
    /// <summary>
    /// Text element positioned next to the player.
    /// </summary>
    private Transform text;
    /// <summary>
    /// Player whose ammo is displayed (taken from the parent <see cref="Pause"/>).
    /// </summary>
    private GameObject Player;
    /// <summary>
    /// Caches the player reference and the text transform.
    /// </summary>
    void Start()
    {
        Player = GetComponentInParent<Pause>().player;
        text = GetComponent<Transform>();
    }

    /// <summary>
    /// Shows the current ammo count and keeps the label next to the player.
    /// </summary>
    void Update()
    {
        GetComponent<Text>().text = Player.GetComponent<controller>().GetAmmo().ToString();
        text.position= Camera.main.WorldToScreenPoint(Player.transform.position+Vector3.right*2);
    }
}
