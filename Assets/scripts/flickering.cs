using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// flickers the ambient light in the scene
/// </summary>
public class flickering : MonoBehaviour
{
    [SerializeField]
    bool change=true;
    bool active = true;
    private Light _light;
    void Start()
    {
        _light = GetComponent<Light>();
    }
    /// <summary>
    /// changes the state of the light
    /// </summary>
    void flicker()
    {
        active = !active;
        _light.enabled = active;
        change = true;
        Debug.Log(active.ToString());
        Debug.Log(change.ToString());
    }
    void Update()
    {
        if (change)
        {
            change = false;
            Debug.Log("change");
            Invoke("flicker", 2);
           
        }
    }
}
