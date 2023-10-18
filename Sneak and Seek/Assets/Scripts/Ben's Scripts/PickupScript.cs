using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] Inventory inventory;

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

    void start()
    {
        inventory = GetComponent<Inventory>();
    }

    // this activates when "X" is pressed on an Xbox controller
    void OnPickUp()
    {
        if (DoesTagExist("Pickup (Active)") == true)
        {
            // This calls the function from inventory to add an item to the players inventory
            inventory.AddItem();

            // This destroys the pickup object
            Destroy(GameObject.FindWithTag("Pickup (Active)"));
        }
    }
}
