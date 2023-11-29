using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    // A variable used to store needed script of the found active door so we don't have to keep GameObject.Find-ing it
    DoorMove activeDoor;

    // The players inventory used for checking keys
    Inventory playerInventory;

    private void Start()
    {
        // Gets the players inventory
        playerInventory = GetComponent<Inventory>();
    }

    void OnOpenDoor()
    {
        //Debug.Log("Input OpenDoor has been called");
        
        // Checks if an active door actually exists
        if (DoesTagExist("Door (Player)") == true)
        {
            // Gets the door
            activeDoor = GameObject.FindWithTag("Door (Player)").GetComponent<DoorMove>();

            // Checks if the door is unlocked or, is locked and the player has the key or, is locked and the player doesn't have the key
            if (activeDoor.isLocked == false)
            {
                // Checks if the door is opened or closed and calls the correct function based on said state
                if (activeDoor.doorIsOpen == false)
                {
                    activeDoor.openDoor();
                }
                else if (activeDoor.doorIsOpen == true)
                {
                    activeDoor.closeDoor();
                } 
            }
            else if (activeDoor.isLocked == true && playerInventory.inventory.Contains(activeDoor.lockID))
            {
                Debug.Log("The door has been unlocked");

                // Sets the door to unlocked
                activeDoor.isLocked = false;

                // Checks if the door is opened or closed and calls the correct function based on said state
                if (activeDoor.doorIsOpen == false)
                {
                    activeDoor.openDoor();
                }
                else if (activeDoor.doorIsOpen == true)
                {
                    activeDoor.closeDoor();
                }

                // Removes the key from the players inventory
                playerInventory.RemoveItem(activeDoor.lockID);
            }
            else if (activeDoor.isDoubleLocked == true && playerInventory.inventory.Contains(activeDoor.lockID) && playerInventory.inventory.Contains(activeDoor.lock2ID))
            {
                Debug.Log("The toy room door has been unlocked");

                activeDoor.isDoubleLocked = false;

                // Checks if the door is opened or closed and calls the correct function based on said state
                if (activeDoor.doorIsOpen == false)
                {
                    activeDoor.openDoor();
                }
                else if (activeDoor.doorIsOpen == true)
                {
                    activeDoor.closeDoor();
                }

                // Removes the keys from the players inventory
                playerInventory.RemoveItem(activeDoor.lockID);
                playerInventory.RemoveItem(activeDoor.lock2ID);
            }
            else
            {
                Debug.Log("This door is locked and you don't have the key");
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
