using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    void OnOpenDoor()
    {
        Debug.Log("Input OpenDoor has been called");

        if (DoesTagExist("Door (Active)") == true)
        {
            if (GameObject.FindGameObjectWithTag("Door (Active)").GetComponent<DoorMove>().doorIsOpen == false)
            {
                GameObject.FindGameObjectWithTag("Door (Active)").GetComponent<DoorMove>().openDoor();
            }
            else if (GameObject.FindGameObjectWithTag("Door (Active)").GetComponent<DoorMove>().doorIsOpen == true)
            {
                GameObject.FindGameObjectWithTag("Door (Active)").GetComponent<DoorMove>().closeDoor();
            }
        }
    }

    // This function checks that an object with a certain tag exists
    private bool DoesTagExist(string tag)
    {
        

        if (GameObject.FindGameObjectsWithTag(tag).Length == 0)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
