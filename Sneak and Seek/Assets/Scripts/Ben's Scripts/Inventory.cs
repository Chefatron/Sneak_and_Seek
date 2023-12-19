using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class Inventory : MonoBehaviour
{
    // Used to store how many candles the player owns
    public int candleAmount;

    // Used to store the key currently in the players first inventory slot
    public int keySlot1;

    // Used to store the key currently in the players second inventory slot
    public int keySlot2;

    // This adds an item to the players inventory (will need to be changed later if needing to accommodate for different items)
    public bool AddItem(int itemID)
    {
        // Checks if its a candle or key as well as if there is room for it then either adds the item or returns a faliure
        if (itemID == 1)
        {
            candleAmount++;
        }
        else if (itemID != 1 && keySlot1 == 0)
        {
            keySlot1 = itemID;
        }
        else if (itemID != 1 && keySlot2 == 0)
        {
            keySlot2 = itemID;
        }
        else
        {
            return false;
        }

        return true;
    }

    // This removes an item from the players inventory (may need altering if different items are being stored)
    public bool RemoveItem(int itemID)
    {
        // Checks if the player has the desired item and either removes or returns a faliure
        if (itemID == 1 && candleAmount > 0)
        {
            candleAmount--;
        }
        else if (itemID == keySlot1)
        {
            keySlot1 = 0;

            // Just checks if there is a key in slot 2 and moves it up a slot for visual goodness
            if (keySlot2 != 0)
            {
                keySlot1 = keySlot2;

                keySlot2 = 0;
            }
        }
        else if (itemID == keySlot2)
        {
            keySlot2 = 0;
        }
        else
        {
            return false;
        }

        return true;
    }
}
