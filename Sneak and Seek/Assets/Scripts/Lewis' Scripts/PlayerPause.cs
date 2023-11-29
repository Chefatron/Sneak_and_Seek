using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        // Disables it by defualt
        pausePanel.SetActive(false);
    }

    void OnPauseMenu()
    {
        pause();
        
    }

    public void pause()
    {
        //Sets the pause panel's active status to whatever it currently isn't out of true or false
        pausePanel.SetActive(!pausePanel.activeInHierarchy);

        if (pausePanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else if (!pausePanel.activeInHierarchy)
        {
            Time.timeScale = 1;
        }

    }
}
