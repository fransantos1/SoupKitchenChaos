using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameBehaviour : MonoBehaviour
{
    public GameObject settings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnGameQuitPressed()
    {
        Application.Quit();
    }

    public void OnSettingsOpen()
    {
        settings.SetActive(true);
    }
}
