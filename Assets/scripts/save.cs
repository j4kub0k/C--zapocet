using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

/// <summary>
/// Save system for the game
/// </summary>
public static class save 
{
    static public string path { get; set;}= Application.persistentDataPath + "/save.json";

  /// <summary>
  /// Tries loading the save file
  /// </summary>
  /// <param name="player"></param>
    public static  bool Load(GameObject player)
    {
        if (System.IO.File.Exists(path)) {  
            string json = System.IO.File.ReadAllText(path); //reads json file
            PLayerData PlayerData = JsonUtility.FromJson<PLayerData>(json); //deserializes json file
            //sets player data to the data from the json file
            player.GetComponent<PlayerKill>().ChangeHealth(PlayerData.GetHealth());
            player.GetComponent<controller>().SetAmmo(PlayerData.GetAmmo());
            player.GetComponent<controller>().SetGun((controller.gunType)PlayerData.GetGun());
            player.transform.position = new Vector3(PlayerData.GetPosition()[0], PlayerData.GetPosition()[1], PlayerData.GetPosition()[2]);
            return true;
        }
        return false;
        
    }

    /// <summary>
    /// Saves player data to a json file in the persistent data path
    /// </summary>
    /// <param name="player"></param>
    public static void Save(GameObject player)
    {
        path = Application.persistentDataPath + "/save.json";
        Debug.Log(path);
        //creating player data object to be serialized
        PLayerData data = new PLayerData(player.GetComponent<PlayerKill>().GetHealth(), player.GetComponent<controller>().GetAmmo(), (int)player.GetComponent<controller>().GetCurrentGun(),new float[] { player.transform.position.x, player.transform.position.y,player.transform.position.z});
        string json = JsonUtility.ToJson(data); //serializes player data
        Debug.Log(data);
        System.IO.File.WriteAllText(path, json);
    }
    /// <summary>
    /// Deletes the save file from the persistent data path
    /// </summary>
    public static void Delete()
    {
        System.IO.File.Delete(path);
    }

    
}
