using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Used to tell update the controller is rumbling
    bool isRumbling;

    // Used to store what time the controller should stop rumbling
    float rumbleStopTime;

    // The player object
    [SerializeField] GameObject player;

    GameObject winBackground;

    // Start is called before the first frame update
    void Start()
    {
        // Sets isRumbling to default of false
        isRumbling = false;

        // Call setupLevel with the current scene name so it can set everything up based on the current level
        SetupLevel(SceneManager.GetActiveScene().buildIndex);

        // Checks if the player pref saves have been made and makes them if not
        if (!PlayerPrefs.HasKey("SavesMade") || PlayerPrefs.GetInt("SavesMade") == 0)
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
            PlayerPrefs.SetInt("CurrentStage", 2);
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
        if (currentScene == 2)
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
        else if (currentScene == 5)
        {
            // Spawn the player

            // Open the doors that were opened prevoisly by the player

            winBackground = GameObject.Find("WinBackground");

            winBackground.SetActive(false);

            PlayerPrefs.SetInt("CurrentStage", 5);
        }
        else if (currentScene == 0)
        {
            // Play title music
        }
    }

    // Loads the loading scene and starts loading the desired scene
    public void LoadScene(int sceneIndex)
    {
        // Unfreezes time just in case
        Time.timeScale = 1f;

        // Loads the loading scene
        SceneManager.LoadSceneAsync(1);

        // Starts the loading of the indexed scene at the same time 
        StartCoroutine(loadAsyncScene(sceneIndex));
    }

    // Used to load the desired scene while the loading scene plays
    IEnumerator loadAsyncScene(int sceneIndex)
    {
        // Loads the scene in the background
        AsyncOperation asyncLoading = SceneManager.LoadSceneAsync(sceneIndex);

        // Checks if the scene is done loading
        while (asyncLoading != null)
        {
            yield return null;
        }
    }

    public void SkipVideo()
    {
        // Sets video to seen
        PlayerPrefs.SetInt("IntroSeen", 1);

        // Loads scene now
        LoadScene(PlayerPrefs.GetInt("CurrentStage"));
    }

    public void PlayGame()
    {
        // Checks if the player has seen the intro video
        if(PlayerPrefs.GetInt("IntroSeen") == 0)
        {
            GameObject.Find("VideoCanvas").GetComponent<VideoPlay>().PlayVideo();
        }
        else 
        {
            // Checks the level the player last saved on to say which level to load
            LoadScene(PlayerPrefs.GetInt("CurrentStage"));
        }        
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

    private void OnTriggerEnter(Collider other)
    {
        winBackground.SetActive(true);

        Time.timeScale = 0f;  
    }
}
