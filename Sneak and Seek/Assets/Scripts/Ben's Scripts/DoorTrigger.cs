using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject Door;
    
    void OnTriggerEnter()
    {
        Door.tag = "Door (Active)";
        Debug.Log("Status: Active");
    }

    void OnTriggerExit()
    {
        Door.tag = "Door";
        Debug.Log("Status: Inactive");
    }
}
