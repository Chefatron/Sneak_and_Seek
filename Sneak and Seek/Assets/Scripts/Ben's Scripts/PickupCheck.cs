using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCheck : MonoBehaviour
{
    [SerializeField] GameObject pickup;

    // Start is called before the first frame update
    void OnTriggerEnter()
    {
        // Replaces the pickup objects tag with "Pickup (Active)" 
        pickup.tag = "Pickup (Active)";
        //Debug.Log("Status: Active");
    }

    void OnTriggerExit()
    {
        // Replaces the pickup objects tag with "Pickup"
        pickup.tag = "Pickup";
        //Debug.Log("Status: Inactive");
    }
}
