using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// elementary weapon for the player
/// </summary>
public class Pistol : MonoBehaviour
{
    private bool canFire = true;
    public int MaxAmmo = 3;
    private int currentAmmo; 
    public int Damage = 1;

    /// <summary>
    /// Returns the current ammo count.
    /// </summary>
    public int GetAmmo()
    {
        return currentAmmo;
    }

    /// <summary>
    /// regulates the fire rate
    /// </summary>
    /// <returns></returns>
    private IEnumerator Reload()
    {
        canFire = false;
        yield return new WaitForSeconds(1);
        canFire = true;
    }

    /// <summary>
    /// controls the ammo and damage of the pistol
    /// </summary>
   public void fire(bool infinit)
    {
        if (currentAmmo > 0 && canFire)
        {
           
                if (!infinit)
                    currentAmmo--;
                GetComponent<Fires>().fire(Damage, null);
                Camera.main.DOShakePosition(0.1f, 3, 10, 90, true);
                StartCoroutine(Reload());
        }
        else
            transform.parent.GetComponent<AudioSource>().Play();
    }

    /// <summary>
    /// Adds ammo, capped at <c>MaxAmmo</c>.
    /// </summary>
    public void AddAmmo(int ammo)
    {
        int x = currentAmmo + ammo;
        if(x <= MaxAmmo)
            currentAmmo = x;
        else
            currentAmmo = MaxAmmo;

    }
    /// <summary>
    /// Sets the ammo count directly (used when loading a save).
    /// </summary>
    public void SetAmmo(int ammo)
    {
        currentAmmo = ammo;
    }

    /// <summary>
    /// Fills the magazine.
    /// </summary>
    public void Start()
    {
        currentAmmo = MaxAmmo;
    }
}
