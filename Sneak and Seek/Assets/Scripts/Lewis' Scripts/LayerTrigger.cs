using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerTrigger : MonoBehaviour
{
    // The player
    [SerializeField] GameObject player;

    // The desired sorting layer to set the player to
    [SerializeField] int layer;

    // if enter trigger change players layer
    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<SortingGroup>().sortingOrder = layer;  
    }
}
