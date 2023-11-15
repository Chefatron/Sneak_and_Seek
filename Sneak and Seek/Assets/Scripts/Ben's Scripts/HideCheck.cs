using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCheck : MonoBehaviour
{
    [SerializeField] GameObject hidingSpot;

    public int nearestNodeID;

    private void Start()
    {

    }

    // When the player walks into the trigger zone, update the hiding spots tag
    private void OnTriggerEnter(Collider other)
    {
        hidingSpot.tag = "Hiding spot (Active)";
        Debug.Log("Status: Active");
    }

    // Reserve the change made to tag to signal that the player is out of range
    private void OnTriggerExit(Collider other)
    {
        hidingSpot.tag = "Hiding spot";
        Debug.Log("Status: Inactive");
    }
}
