using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessChange : MonoBehaviour
{
    float brightness;

    [SerializeField] Slider brightnessSlider;

    LiftGammaGain gammaVolume;

    private void Start()
    {
        // Gets the global volume for the brightness adjustment
        gammaVolume = GetComponent<LiftGammaGain>();

        // Checks if has save, makes if not
        if (!PlayerPrefs.HasKey("Brightness"))
        {
            PlayerPrefs.SetFloat("Brightness",1f);
        }

        // Assigns default vals
        Screen.brightness = PlayerPrefs.GetFloat("Brightness");
        brightnessSlider.value = PlayerPrefs.GetFloat("Brightness");
    }

    // Update is called once per frame
    void Update()
    {
        // Changes the brightness based on the slider
        brightness = brightnessSlider.value;

        Debug.Log(gammaVolume.gamma.ToString());

        // Updates the brightness
        gammaVolume.gamma.Override(new Vector4(0, 0, 0, brightness));
    }
}
