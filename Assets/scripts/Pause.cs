using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the pause menu
/// </summary>
public class Pause : MonoBehaviour
{
    public GameObject player;
    private GameObject canvas;
    void Start()
    {
        canvas=transform.GetChild(0).gameObject;
        Go();
    }
   

    private void Go()
    {
        canvas.SetActive(false);
        for (int i = 1; i < 4; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        player.GetComponent<controller>().enabled = true;

    }
    /// <summary>
    ///  Resume the game and hide the pause menu
    /// </summary>
    public void Resume()
    {
        Go();
        Time.timeScale = 1;
    }
    /// <summary>
    /// Saves player data and hides the pause menu
    /// </summary>

    public void Save()
    {
      
        save.Save(player);
        Go();
        Time.timeScale = 1;
    }
    /// <summary>
    /// Loads the last save and hides the pause menu
    /// </summary>
    public void Load()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Go();
        Time.timeScale = 1;
    }

    /// <summary>
    /// Quitting the application and saving the player data
    /// </summary>
    public void Quit()
    {
        Camera.main.DOKill();
        save.Save(player);
        Debug.Log("Quit");
        Application.Quit();
    }
    /// <summary>
    /// Deleting the save and reseting the game
    ///  </summary>
    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        save.Delete();
        player.GetComponent<controller>().enabled = true;
        Camera.main.DOKill();
    }
   private void Update()
    {
        //checking if the player pressed the escape key to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            player.GetComponent<controller>().enabled = false;
            canvas.SetActive(!canvas.activeSelf);
            if (canvas.activeSelf)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
                for(int i = 1; i < 4; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
            else
            {
              
                Time.timeScale = 1;
                Go();
            }
        }
        
    }
}
