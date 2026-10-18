using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// class that holds the player's data to be saved
/// </summary>
[Serializable]
public  class PLayerData
{
    [SerializeField]
    int Health;
    [SerializeField]
    int Ammo;
    [SerializeField]
    int Gun;
    [SerializeField]
    float[] position= new float[3];

    /// <summary>
    /// Creates a snapshot of the player's state.
    /// </summary>
    public PLayerData(int health, int ammo, int gun, float[] position)
    {
        Health = health;
        Ammo = ammo;
        Gun = gun;
        this.position =position;
    }

    /// <summary>
    /// Returns the saved health.
    /// </summary>
    public int GetHealth()
    {
        return Health;
    }
    /// <summary>
    /// Returns the saved ammo of the current gun.
    /// </summary>
    public int GetAmmo()
    {
        return Ammo;
    }
    /// <summary>
    /// Returns the saved gun as an index of <c>controller.gunType</c>.
    /// </summary>
    public int GetGun()
    {
        return Gun;
    }
    /// <summary>
    /// Returns the saved position as x, y, z.
    /// </summary>
    public float[] GetPosition()
    {
        return position;
    }

    /// <summary>
    /// Readable form used for debug logging.
    /// </summary>
    public override string ToString()
    {
        return $"Heath:{Health} Ammo:{Ammo} Gun:{Gun} Position {position}";
    }
}
