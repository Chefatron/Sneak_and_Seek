using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCheck : MonoBehaviour
{
    [SerializeField] GameObject pickup;

    [SerializeField] GameObject xButton;

    public int ID;

    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        // Replaces the pickup objects tag with "Pickup (Active)" 
        pickup.tag = "Pickup (Active)";

        xButton.SetActive(true);
        //Debug.Log("Status: Active");
    }

    void OnTriggerExit()
    {
        // Replaces the pickup objects tag with "Pickup"
        pickup.tag = "Pickup";

        xButton.SetActive(false);
        //Debug.Log("Status: Inactive");
    }
}
