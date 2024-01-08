using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessChange : MonoBehaviour
{
    float brightness;

    [SerializeField] Slider brightnessSlider;

    LiftGammaGain LGG;
    [SerializeField] Volume gammaVolume;

    private void Start()
    {
        // Gets the global volume for the brightness adjustment
        //gammaVolume = GetComponent<Volume>();

        // Checks if has save, makes if not
        if (!PlayerPrefs.HasKey("Brightness"))
        {
            PlayerPrefs.SetFloat("Brightness", 0f);
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

        try
        {
            gammaVolume.profile.TryGet(out LGG);
            //Debug.Log("It worked");
            //Debug.Log(LGG.gamma);
            LGG.gamma.Override(new Vector4(1f, 1f, 1f, brightness));
        } 
        catch (System.Exception)
        {
            //Debug.Log("It didn't work");
        }
        

        // Updates the brightness
        //gammaVolume.gamma.Override(new Vector4(0, 0, 0, brightness));
    }

    public void updateSave()
    {
        PlayerPrefs.SetFloat("Brightness", brightness);
    }
}
