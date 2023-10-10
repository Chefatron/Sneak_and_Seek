using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<int> inventory = new List<int>();

    // This adds an item to the players inventory (will need to be changed later if needing to accommodate for different items)
    public void AddItem()
    {
        inventory.Add(1);
    }

    // This removes an item from the players inventory (may need altering if different items are being stored)
    public void RemoveItem()
    {
        inventory.RemoveAt(inventory.Count);
    }
}
