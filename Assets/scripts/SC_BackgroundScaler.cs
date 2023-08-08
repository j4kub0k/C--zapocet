using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// scales the background image to fit the screen
/// </summary>
public class SC_BackgroundScaler : MonoBehaviour
{
    Image backgroundImage;
    RectTransform rt;
    float ratio;

    
    void Start()
    {
        backgroundImage = GetComponent<Image>();
        rt = backgroundImage.rectTransform;
        ratio = backgroundImage.sprite.bounds.size.x / backgroundImage.sprite.bounds.size.y;
    }

    void Update()
    {
        if (!rt)
            return;

        if (Screen.height * ratio >= Screen.width)
        {
            rt.sizeDelta = new Vector2(Screen.height * ratio, Screen.height);
        }
        else
        {
            rt.sizeDelta = new Vector2(Screen.width, Screen.width / ratio);
        }
    }
}