using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the pause panel
        pausePanel = GameObject.Find("Pause Panel");

        // Disables it by defualt
        pausePanel.SetActive(false);
    }

    void OnPauseMenu()
    {
        // Sets the pause panel's active status to whatever it currently isn't out of true or false
        pausePanel.SetActive(!pausePanel.activeInHierarchy);
    }
}
