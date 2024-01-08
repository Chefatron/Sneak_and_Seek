using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioChange : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] UnityEngine.UI.Slider volumeSlider;

    //public float audioValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value;
    }
}
