using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject Door;
    
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Door.tag = "Door (Enemy)";
        }
        else if (other.CompareTag("Player"))
        {
            Door.tag = "Door (Player)";
        }
    }

    void OnTriggerExit(Collider other)
    {
            Door.tag = "Door";
    }
}
