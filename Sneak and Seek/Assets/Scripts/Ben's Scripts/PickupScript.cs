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

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    // this activates when "X" is pressed on an Xbox controller
    void OnPickUp()
    {
        if (DoesTagExist("Pickup (Active)") == true)
        {
            // This calls the function from inventory to add the correct item id to the players inventory
            inventory.AddItem(GameObject.FindGameObjectWithTag("Pickup (Active)").GetComponent<PickupCheck>().ID);

            // This destroys the pickup object
            Destroy(GameObject.FindWithTag("Pickup (Active)"));
        }
    }
}
