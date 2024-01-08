using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LayerTrigger : MonoBehaviour
{

    // The desired sorting layer to set the player to
    [SerializeField] int layer;

    // if enter trigger change players layer
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<SortingGroup>().sortingOrder = layer;
        }
    }
}
