using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandleManager : MonoBehaviour
{
    // The candle light attached to the player
    [SerializeField] Light candle;

    // Used to set the range of the players candle
    public float lightValue;

    Inventory inventory;

    [SerializeField] GameManager gameManager;

    // The ui element for the candle
    [SerializeField] Image candleBar;

    bool resetLight;

    float deathTimer;


    // Start is called before the first frame update
    void Start()
    {
        // Sets the light value to the defualt value of 90
        //lightValue = 100;

        // Gets the inventory script from the player
        inventory = GetComponent<Inventory>();

        deathTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the candle reaches a low enough level and either keeps lowering it or checks if the player has a candle item to refill it and then resets it slowly if needed
        if (resetLight == true)
        {
            // Checks if it hasn't reached the desired value and increases if not
            if (lightValue < 100)
            {
                lightValue = lightValue + (50 * Time.deltaTime);

                candleBar.fillAmount = lightValue / 100;
            }
            else
            {
                lightValue = 100;

                candleBar.fillAmount = lightValue / 100;

                resetLight = false;
            }
        }
        else if (lightValue > 0)
        {
            // Lowers the light value
            if (lightValue > 50)
            {
                lightValue = lightValue - (1f * Time.deltaTime);
            }
            else if (lightValue > 25)
            {
                lightValue = lightValue - (2f * Time.deltaTime);
            }
            else 
            {
                lightValue = lightValue - (4f * Time.deltaTime);
            }

            candleBar.color = new Color32(255, Convert.ToByte(lightValue * 2.55f), Convert.ToByte(lightValue * 2.55f), 255);

            candleBar.fillAmount = lightValue / 100;

            //print("Lightvalue: " + lightValue);

            //Debug.Log("Lightvalue: " + lightValue);
        }
        else if (inventory.candleAmount > 0)
        {
            // Calls the remove function item and removes the correct item
            inventory.RemoveItem(1);

            deathTimer = 0;

            candleBar.color = new Color32(255, 255, 255, 255);

            resetLight = true;
        }
        else
        {
            if (deathTimer < 3)
            {
                deathTimer = deathTimer + Time.deltaTime;

                GameObject.Find("Game Manager").GetComponent<GameManager>().Rumble(deathTimer, 0.1f);
            }
            else if (deathTimer >= 3)
            {
                GameObject.Find("Game Manager").GetComponent<GameManager>().Rumble(0f, 0f);

                gameManager.ResetScene();
            }
        }

        // Sets the light value devided by an amount so it is reasonable for a lights range
        candle.intensity = lightValue;
    }
}
