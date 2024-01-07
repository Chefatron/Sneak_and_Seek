using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PickupScript : MonoBehaviour
{
    [SerializeField] Inventory inventory;

    [SerializeField] GameManager gameManager;

    [SerializeField] List<GameObject> notes = new List<GameObject>();

    [SerializeField] GameObject backButton;

    PickupCheck currentPickup;

    // Used to check if the inventory has the capacity for the item being added
    bool inventorySuccess;

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

            if (currentPickup.ID < 16)
            {
                // This calls the function from inventory to add the correct item id to the players inventory
                inventorySuccess = inventory.AddItem(currentPickup.ID);

                if (inventorySuccess == true)
                {
                    // This destroys the pickup object
                    Destroy(currentPickup.gameObject);
                }
                else if (inventorySuccess == false) 
                {
                    Debug.Log("The inv was full");
                }
            }
            else if (currentPickup.ID > 16)
            {
                inventory.addNote(currentPickup.ID);

                notes[currentPickup.ID - 17].SetActive(true);

                backButton.SetActive(true);

                backButton.GetComponent<Button>().Select();
            }    
            else
            {
                // Calls the dark level
                gameManager.LoadScene(4);
            }
        }
    }
}
