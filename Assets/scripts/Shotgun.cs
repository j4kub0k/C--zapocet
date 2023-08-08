using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controles the shotgun's ammo and damage
/// </summary>
public class Shotgun : MonoBehaviour
{
   public int ammo = 5;
    public int Damage = 1;

    /// <summary>
    /// Makes the shotgun fire and shake the camera
    /// controles if the ammo is infinite or not
    /// </summary>
    /// <param name="infinit"></param>
   public void fire(bool infinit)
   {

        if (ammo > 0)
        {
            if (!infinit) 
                ammo--;
            GetComponent<ShotgunFires>().fire(Damage);
            Camera.main.DOShakePosition(0.1f, 5, 10, 90, true);
        }
        else
            GetComponentInParent<controller>().SetGun(controller.gunType.pistol);

   }
}
