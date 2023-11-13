using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessChange : MonoBehaviour
{
    public float brightness;

    // Update is called once per frame
    void Update()
    {
        brightness = GetComponent<UnityEngine.UI.Slider>().value;

        if (brightness < 0.2f)
        {
            brightness = 0.2f;
        }

        Screen.brightness = brightness;
    }
}
