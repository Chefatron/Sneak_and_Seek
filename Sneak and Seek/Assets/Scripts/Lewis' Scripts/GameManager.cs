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
        setupLevel(SceneManager.GetActiveScene().name);
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

    void setupLevel(string currentScene)
    {
        if (currentScene == "First Floor")
        {
           
        }
        else if (currentScene == "Ground Floor")
        {

        }
        else if (currentScene == "Dark Ground Floor")
        {

        }
        else if (currentScene == "Dark First Floor")
        {

        }
        else if (currentScene == "Title Screen")
        {

        }
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(sceneName);
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }  
}
