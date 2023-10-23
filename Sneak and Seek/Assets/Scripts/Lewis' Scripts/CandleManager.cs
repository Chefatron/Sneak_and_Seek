using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleManager : MonoBehaviour
{
    // The candle light attached to the player
    Light candle;

    // Used to set the range of the players candle
    float lightValue;

    // Start is called before the first frame update
    void Start()
    {
        // Finds the players candle light and assigns it to candle
        candle = GameObject.Find("Candle").GetComponent<Light>();

        // Sets the light value to the defualt value of 90
        lightValue = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (lightValue > 0.5)
        {
            lightValue = lightValue - 0.0001f;
        }
        else
        {
            lightValue = 3;
        }

        // Sets the light value devided by an amount so it is reasonable for a lights range
        candle.intensity = lightValue;
    }
}
