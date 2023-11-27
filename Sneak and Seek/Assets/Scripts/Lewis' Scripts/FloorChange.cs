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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.LoadScene(sceneIndex);
    }
}
