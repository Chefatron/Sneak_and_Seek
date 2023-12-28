using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    // The gamemanager script
    [SerializeField] GameManager gameManager;

    // The name of the scene for the stairs to load
    [SerializeField] int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger active");
        //Debug.Log(other.gameObject.tag);

        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Found");
            gameManager.LoadScene(sceneIndex);
        }
    }
}
