
using UnityEngine;

/// <summary>
/// Handles the main menu of the game
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Root object of the menu UI.
    /// </summary>
    public GameObject mainMenu;
    /// <summary>
    /// Shows the menu.
    /// </summary>
    void Start()
    {
        mainMenu.SetActive(true);
    }
    /// <summary>
    /// Starts new game and deletes old save
    /// </summary>
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
        save.Delete();
    }
    /// <summary>
    /// Starts game and loads last save
    /// </summary>
    public void ContinueGame()
    {
        if(System.IO.Directory.Exists(save.path))
            UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}
