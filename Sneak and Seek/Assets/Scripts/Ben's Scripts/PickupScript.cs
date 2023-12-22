using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] GameManager gameManager;

    PickupCheck currentPickup;

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

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // this activates when "X" is pressed on an Xbox controller
    void OnPickUp()
    {
        if (DoesTagExist("Pickup (Active)") == true)
        {
            // Gets the active pick up
            currentPickup = GameObject.FindWithTag("Pickup (Active)").GetComponent<PickupCheck>();

            if (currentPickup.ID != 16)
            {
                // This calls the function from inventory to add the correct item id to the players inventory
                inventory.AddItem(currentPickup.ID);

                // This destroys the pickup object
                Destroy(currentPickup.gameObject);
            }
            else
            {
                // Calls the dark level
                gameManager.LoadScene(4);
            }
        }

        else if (DoesTagExist("Note (Active)") == true)
        {
            currentPickup = GameObject.FindWithTag("Note (Active)").GetComponent<PickupCheck>();

            for (int i = 0; i < gameManager.notesInventory.Length; i++)
            {
                if (gameManager.notesInventory[i] == 0)
                {
                    gameManager.notesInventory[i] = currentPickup.ID;
                }
            }

            Destroy(currentPickup.gameObject);

        }
    }
}
