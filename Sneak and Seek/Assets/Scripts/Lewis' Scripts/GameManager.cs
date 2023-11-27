using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Used to tell update the controller is rumbling
    bool isRumbling;

    // Used to store what time the controller should stop rumbling
    float rumbleStopTime;

    // The player object
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // Sets isRumbling to default of false
        isRumbling = false;

        // Call setupLevel with the current scene name so it can set everything up based on the current level
        SetupLevel(SceneManager.GetActiveScene().buildIndex);

        // Checks if the player pref saves have been made and makes them if not
        if (!PlayerPrefs.HasKey("SavesMade") || PlayerPrefs.GetInt("SavesMade") == 1)
        {
            CreateSaves();
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the controller is rumbling
        if (isRumbling == true)
        {
            // Checks if the system time has passed the rumble stop time
            if (Time.unscaledTime > rumbleStopTime)
            {
                // Turns of the motors
                Gamepad.current.SetMotorSpeeds(0, 0);

                // Resets is rumbling to false
                isRumbling = false;
            }
        }
    }

    void CreateSaves()
    {
        // Checks if all of the necessary saves for the game have been made
        if (!PlayerPrefs.HasKey("IntroSeen"))
        {
            PlayerPrefs.SetInt("IntroSeen", 0);
        }

        if (!PlayerPrefs.HasKey("TutorialCompleted"))
        {
            PlayerPrefs.SetInt("TutorialCompleted", 0);
        }

        // Current stage is 1 because we don't want it to load the player into the tutorial
        if (!PlayerPrefs.HasKey("CurrentStage"))
        {
            PlayerPrefs.SetInt("CurrentStage", 1);
        }

        if (!PlayerPrefs.HasKey("CandleAmount"))
        {
            PlayerPrefs.SetInt("CandleAmount", 0);
        }

        if (!PlayerPrefs.HasKey("KeyID1"))
        {
            PlayerPrefs.SetInt("KeyID1", 0);
        }

        if (!PlayerPrefs.HasKey("KeyID2"))
        {
            PlayerPrefs.SetInt("KeyID2", 0);
        }

        PlayerPrefs.SetInt("SavesMade", 1);
    }

    void SetupLevel(int currentScene)
    {
        if (currentScene == 1)
        {
            // Spawn the player

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 1);
        }
        else if (currentScene == 2)
        {
            // Spawn the player

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 2);
        }
        else if (currentScene == 3)
        {
            // Spawn the player

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 3);
        }
        else if (currentScene == 4)
        {
            // Spawn the player

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 4);
        }
        else if (currentScene == 0)
        {
            // Play title music
        }
    }

    public void LoadScene(int sceneIndex)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneIndex);
    }

    public void PlayGame()
    {
        // Checks the level the player last saved on to say which level to load
        LoadScene(PlayerPrefs.GetInt("CurrentStage"));     
    }

    public void CloseGame()
    {
        // Closes the application, only works in build
        Application.Quit();
    }

    public void Rumble(float power, float time)
    {
        // Turns on motors set to fed power
        Gamepad.current.SetMotorSpeeds(power, power);

        // Sets isRumbling to true
        isRumbling = true;

        // Calculates the time to stop rumbling based on current time plus the time fed into the function
        rumbleStopTime = Time.unscaledTime + time;
    }

    public void ResetScene()
    {
        Debug.Log("Scene has been reset");

        Time.timeScale = 1f;

        // Resets the current scene loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }  
}
