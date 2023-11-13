using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Inventory : MonoBehaviour
{
    public List<int> inventory = new List<int>();

    // This adds an item to the players inventory (will need to be changed later if needing to accommodate for different items)
    public void AddItem(int itemID)
    {
        // Adds said item to the list
        inventory.Add(itemID);
    }

    // This removes an item from the players inventory (may need altering if different items are being stored)
    public void RemoveItem(int itemID)
    {
        // Removes the first instance of the specified item in the list
        inventory.Remove(itemID);
    }
}
