using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        // Makes all the saves and sets them to defualt vals
        PlayerPrefs.SetInt("IntroSeen", 0);

        PlayerPrefs.SetInt("TutorialCompleted", 0);

        PlayerPrefs.SetInt("CurrentStage", 2);

        PlayerPrefs.SetInt("CandleAmount", 0);
        
        PlayerPrefs.SetFloat("LightLevel", 100f);

        PlayerPrefs.SetInt("KeyID1", 0);

        PlayerPrefs.SetInt("KeyID2", 0);

        // Sets the one that says the saves are made
        PlayerPrefs.SetInt("SavesMade", 1);
    }

    void SetupLevel(int currentScene)
    {
        Debug.Log("CandleAmount has been read as: " + PlayerPrefs.GetInt("CandleAmount"));

        Debug.Log("LightLevel has been read as: " + PlayerPrefs.GetFloat("LightLevel"));

        Debug.Log("KeyID1 has been read as: " + PlayerPrefs.GetInt("KeyID1"));

        Debug.Log("KeyID2 has been read as:  " + PlayerPrefs.GetInt("KeyID2"));

        if (currentScene == 2)
        {
            // Spawn the player

            // Reads the saves to give the correct values
            player.GetComponent<Inventory>().candleAmount = PlayerPrefs.GetInt("CandleAmount");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID1");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID2");

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 2);
        }
        else if (currentScene == 3)
        {
            // Spawn the player

            // Reads the saves to give the correct values
            player.GetComponent<Inventory>().candleAmount = PlayerPrefs.GetInt("CandleAmount");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID1");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID2");

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 3);
        }
        else if (currentScene == 4)
        {
            // Spawn the player

            // Reads the saves to give the correct values
            player.GetComponent<Inventory>().candleAmount = PlayerPrefs.GetInt("CandleAmount");

            player.GetComponent<CandleManager>().lightValue = PlayerPrefs.GetFloat("LightLevel");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID1");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID2");

            // Open the doors that were opened prevoisly by the player

            PlayerPrefs.SetInt("CurrentStage", 4);
        }
        else if (currentScene == 5)
        {
            // Spawn the player

            // Reads the saves to give the correct values
            player.GetComponent<Inventory>().candleAmount = PlayerPrefs.GetInt("CandleAmount");

            player.GetComponent<CandleManager>().lightValue = PlayerPrefs.GetFloat("LightLevel");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID1");

            player.GetComponent<Inventory>().keySlot1 = PlayerPrefs.GetInt("KeyID2");

            // Open the doors that were opened prevoisly by the player

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

        // Saves all the stuff only if the current scene isn't the main menu
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            Debug.Log("The saves saved supposedly ran");

            // Saves the amount of candles owned
            PlayerPrefs.SetInt("CandleAmount", player.GetComponent<Inventory>().candleAmount);

            // Checks if the candle is in play and saves the current level its at
            if (player.GetComponent<CandleManager>() != null)
            {
                PlayerPrefs.SetFloat("LightLevel", player.GetComponent<CandleManager>().lightValue);
            }

            // Saves both keys currently held by the player
            PlayerPrefs.SetInt("KeyID1", player.GetComponent<Inventory>().keySlot1);
            PlayerPrefs.SetInt("KeyID2", player.GetComponent<Inventory>().keySlot2);


            Debug.Log("CandleAmount has been saved as: " + PlayerPrefs.GetInt("CandleAmount"));

            Debug.Log("LightLevel has been saved as: " + PlayerPrefs.GetFloat("LightLevel"));

            Debug.Log("KeyID1 has been saved as: " + PlayerPrefs.GetInt("KeyID1"));

            Debug.Log("KeyID2 has been saved as:  " + PlayerPrefs.GetInt("KeyID2"));
        }


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

    public void quitToMenu()
    {
        // Loads the loading scene
        SceneManager.LoadSceneAsync(1);

        // Starts the loading of the indexed scene at the same time 
        StartCoroutine(loadAsyncScene(0));
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
        Time.timeScale = 0f;  
    }
}
