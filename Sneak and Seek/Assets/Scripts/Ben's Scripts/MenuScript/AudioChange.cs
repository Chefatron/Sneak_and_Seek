using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioChange : MonoBehaviour
{
    [SerializeField] UnityEngine.UI.Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1f);
        }
    }

    

    public void updateVolumeSave()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }
}
