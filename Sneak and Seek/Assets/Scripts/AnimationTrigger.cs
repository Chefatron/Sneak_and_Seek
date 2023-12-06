using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationTrigger : MonoBehaviour
{
    public Animator objectToAnimate;
    public TextMeshProUGUI promptText;


    private bool inTrigger = false;
    private bool doorOpen = false;


    Keyboard keyboard;
    GameObject player;


    private void Start()
    {
        keyboard = InputSystem.GetDevice<Keyboard>();
    }


    private void Update()
    {
        if (inTrigger && (keyboard.fKey.wasPressedThisFrame))
        {
            if (!doorOpen)
            {
                objectToAnimate.SetBool("Animate",true);
                doorOpen = true;
            }
            else
            {
                objectToAnimate.SetBool("Animate", false);
                doorOpen = false;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            promptText.gameObject.SetActive(true);
            inTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            promptText.gameObject.SetActive(false);
            inTrigger = false;
        }
    }
}
   