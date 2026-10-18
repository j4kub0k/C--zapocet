using UnityEngine;

/// <summary>
/// Checks if there are any enemies left in the scene. If there are none, the canvas is activated and the light is turned on.
/// </summary>
public class EnemyCount : MonoBehaviour
{

    public Canvas canvas;
    public Light dir;
    /// <summary>
    /// Unused; kept for Unity's component lifecycle.
    /// </summary>
    void Start()
    {
        
    }

    // Update is called once per frame
    /// <summary>
    /// Activates the win UI and light once the enemy container has no children left.
    /// </summary>
    void Update()
    {
        if(this.transform.childCount == 0)
        {
            canvas.gameObject.SetActive(true);
            dir.gameObject.SetActive(true);
            dir.GetComponent<flickering>().enabled = false;
            dir.GetComponent<Light>().enabled = true;
            dir.intensity = 1;
        }
    }
}
