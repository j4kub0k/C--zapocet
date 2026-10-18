using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the pause menu
/// </summary>
public class Pause : MonoBehaviour
{
    /// <summary>
    /// The player object controlled and saved by the menu.
    /// </summary>
    public GameObject player;
    private GameObject canvas;
    /// <summary>
    /// Hides the pause menu at the start of the scene.
    /// </summary>
    void Start()
    {
        canvas=transform.GetChild(0).gameObject;
        Go();
    }
   

    /// <summary>
    /// Hides the pause menu, shows the HUD and gives control back to the player.
    /// </summary>
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
   /// <summary>
   /// Toggles the pause menu on the Escape key and freezes time while paused.
   /// </summary>
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
