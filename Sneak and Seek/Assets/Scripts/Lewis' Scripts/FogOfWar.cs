using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogOfWar : MonoBehaviour
{
    [SerializeField] GameObject furnitureParent;

    [SerializeField] List<GameObject> furnitureList;

    private void Start()
    {
        //for (int i = 0; i < furnitureList.Count; i++)
        //{
        //    furnitureList[i].gameObject.SetActive(false);
        //}

        furnitureParent.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //for (int i = 0; i < furnitureList.Count; i++)
            //{
            //    furnitureList[i].gameObject.SetActive(true);
            //}

            furnitureParent.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //for (int i = 0; i < furnitureList.Count; i++)
            //{
            //    furnitureList[i].gameObject.SetActive(false);
            //}

            furnitureParent.SetActive(false);
        }
    }
}
