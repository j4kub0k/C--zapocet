using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles the game over screen
/// </summary>
public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    
    void Start()
    {
        gameObject.SetActive(true);
        Camera.main.DOKill();
    }
    /// <summary>
    /// Deleting save and restarting game
    /// </summary>
    public void Restart()
    {
        save.Delete();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Deleting save and loading main menu
    /// </summary>
    public void MaimMenu()
    {
        save.Delete();
        UnityEngine.SceneManagement.SceneManager.LoadScene("mm");
    }
   
}
