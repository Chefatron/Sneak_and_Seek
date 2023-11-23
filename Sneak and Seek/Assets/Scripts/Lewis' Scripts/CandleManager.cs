using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    // The candle light attached to the player
    [SerializeField] Light candle;

    // Used to set the range of the players candle
    float lightValue;

    Inventory inventory;

    [SerializeField] GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Sets the light value to the defualt value of 90
        lightValue = 3;

        // Gets the inventory script from the player
        inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the candle reaches a low enough level and either keeps lowering it or checks if the player has a candle item to refill it
        if (lightValue > 0.5)
        {
            // Lowers the light value
            lightValue = lightValue - 0.05f * Time.deltaTime;

            //print("Lightvalue: " + lightValue);

            //Debug.Log("Lightvalue: " + lightValue);
        }
        else if (inventory.inventory.Contains(1))
        {
            // Calls the remove function item and removes the correct item
            inventory.RemoveItem(1);

            // Resets light value
            lightValue = 3;
        }
        else
        {
            //gameManager.ResetScene();
        }

        // Sets the light value devided by an amount so it is reasonable for a lights range
        candle.intensity = lightValue;
    }
}
