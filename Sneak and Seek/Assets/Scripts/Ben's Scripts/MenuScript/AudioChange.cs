using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AudioChange : MonoBehaviour
{
    AudioSource audioSource;
    public float audioValue;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioValue = GetComponent<UnityEngine.UI.Slider>().value;
        audioSource.volume = audioValue;
    }
}
