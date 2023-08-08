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

    public PLayerData(int health, int ammo, int gun, float[] position)
    {
        Health = health;
        Ammo = ammo;
        Gun = gun;
        this.position =position;
    }

    public int GetHealth()
    {
        return Health;
    }
    public int GetAmmo()
    {
        return Ammo;
    }
    public int GetGun()
    {
        return Gun;
    }
    public float[] GetPosition()
    {
        return position;
    }

    public override string ToString()
    {
        return $"Heath:{Health} Ammo:{Ammo} Gun:{Gun} Position {position}";
    }
}
