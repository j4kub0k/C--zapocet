using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// doubles the player's gun damage on collision
/// </summary>
public class Damage_Boost : MonoBehaviour
{
    private IEnumerator SetBack(GameObject player , controller.gunType gun)
    {
        yield return new WaitForSeconds(5);
        player.GetComponentInChildren<Text>().enabled = false;
        switch (gun)
        {
            case controller.gunType.pistol:
                player.GetComponentInChildren<Pistol>().Damage /= 2;
                break;
            case controller.gunType.machinegun:
                player.GetComponentInChildren<machinegun>().Damage /= 2;
                break;
            case controller.gunType.shotgun:
                player.GetComponentInChildren<Shotgun>().Damage /= 2;
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<Text>().enabled = true;
            collision.gameObject.GetComponentInChildren<Text>().text = "Damage Boost";
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Collider>().enabled = false;
           var gun= collision.gameObject.GetComponent<controller>().GetCurrentGun();
            switch (gun)
            {
                case controller.gunType.pistol:
                    collision.gameObject.GetComponentInChildren<Pistol>().Damage*=2;
                    break;
                case controller.gunType.machinegun:
                    collision.gameObject.GetComponentInChildren<machinegun>().Damage *= 2;
                    break;
                case controller.gunType.shotgun:
                    collision.gameObject.GetComponentInChildren<Shotgun>().Damage *= 2;
                    break;
            }
            StartCoroutine(SetBack(collision.gameObject, gun));
        }
    }
}
