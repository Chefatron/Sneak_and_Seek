using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUse : MonoBehaviour
{
    // A variable used to store needed script of the found active door so we don't have to keep GameObject.Find-ing it
    DoorMove activeDoor;

    // The players inventory used for checking keys
    Inventory playerInventory;

    // Used to check if the locked door found the right key in the inventory
    bool doorSuccess;

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
            activeDoor = GameObject.FindWithTag("Door (Player)").GetComponentInParent<DoorMove>();

            // Checks if the door is unlocked or, is locked and the player has the key or, is locked and the player doesn't have the key
            if (activeDoor.isLocked == false && activeDoor.isDoubleLocked == false)
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
            else if (activeDoor.isLocked == true)
            {
                Debug.Log("The door has been unlocked");

                // Runs the inventory check
                doorSuccess = playerInventory.RemoveItem(activeDoor.lockID);

                // Checks if the player did indeed have the key and opens the door if so
                if (doorSuccess == true)
                {
                    // Sets the door to unlocked
                    activeDoor.isLocked = false;

                    // Clears the unnecessary lockID
                    activeDoor.lockID = 0;

                    // Checks if the door is opened or closed and calls the correct function based on said state
                    if (activeDoor.doorIsOpen == false)
                    {
                        activeDoor.openDoor();
                    }
                    else if (activeDoor.doorIsOpen == true)
                    {
                        activeDoor.closeDoor();
                    }

                    // Resets doorSuccess
                    doorSuccess = false;
                }
                if (doorSuccess == false)
                {
                    Debug.Log("This door is locked and you don't have the key");
                }
            }
            else if (activeDoor.isDoubleLocked == true)
            {
                // Runs the inventory check for the first lockID
                doorSuccess = playerInventory.RemoveItem(activeDoor.lockID);

                // Checks if the inv check was successful or not
                if (doorSuccess == true)
                {
                    // Sets the door to no longer double locked but instead single locked
                    activeDoor.isDoubleLocked = false;
                    activeDoor.isLocked = true;

                    // Sets the single lockID to the now unnecessary lock2ID
                    activeDoor.lockID = activeDoor.lock2ID;

                    // Clears the lock2ID
                    activeDoor.lock2ID = 0;

                    Debug.Log("You had the first locks key congrats");
                }
                else if (doorSuccess == false)
                {
                    // Runs the inventory check for the second lock ID
                    doorSuccess = playerInventory.RemoveItem(activeDoor.lock2ID);

                    // Checks if the second inv check was successful or not
                    if (doorSuccess == true) 
                    {
                        // Sets the door to no longer double locked but instead single locked
                        activeDoor.isDoubleLocked = false;
                        activeDoor.isLocked = true;

                        // Clears the lock2ID
                        activeDoor.lock2ID = 0;

                        Debug.Log("You had the second locks key congrats");
                    }
                    else
                    {
                        Debug.Log("This door is locked and you don't have either key");
                    }
                }
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
