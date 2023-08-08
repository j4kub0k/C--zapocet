using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  This script is used to control the machine gun's fire rate and ammo
/// </summary>
public class machinegun : MonoBehaviour
{
    private bool canShoot = true;
    public int Ammo = 20;
    public int Damage = 1;
    public AudioClip audioClip;

    /// <summary>
    /// this method is used to control the fire rate of the machine gun
    /// </summary>
    /// <returns>IEnumerator</returns>
    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    /// <summary>
    /// this method is used to fire the machine gun and control the ammo
    /// </summary>
    /// <param name="infinit"></param>
    public void fire(bool infinit)
    {
        if (Input.GetMouseButton(0))
        {
            if (canShoot && Ammo > 0)
            {   
                if(!infinit)
                    Ammo--;
                GetComponent<Fires>().fire(Damage,audioClip);
                Camera.main.DOShakePosition(0.1f, 5, 10, 90, true);
                canShoot = false;
                StartCoroutine(Shoot());
            }
            else if (Ammo == 0)
                GetComponentInParent<controller>().SetGun(controller.gunType.pistol);
        }
    }
}
