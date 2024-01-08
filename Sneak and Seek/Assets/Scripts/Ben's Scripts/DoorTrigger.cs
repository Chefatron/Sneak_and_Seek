using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject Door;

    [SerializeField] GameObject xButton;

    [SerializeField] GameObject keyIcon;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.tag);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Door.tag = "Door (Enemy)";
        }
        else if (other.CompareTag("Player") && (GetComponentInParent<DoorMove>().isLocked || GetComponentInParent<DoorMove>().isDoubleLocked))
        {
            Door.tag = "Door (Player)";

            keyIcon.SetActive(true);
        }
        else if (other.CompareTag("Player"))
        {
            Door.tag = "Door (Player)";

            xButton.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Door.tag = "Door";

        xButton.SetActive(false);
    }
}
