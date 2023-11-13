using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorChange : MonoBehaviour
{
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("The stair trigger has been entered");

        if (SceneManager.GetActiveScene().name == "1st Level")
        {
            //Debug.Log("Loading 2nd level");
            gameManager.LoadScene("2nd Level");
        }
        else if (SceneManager.GetActiveScene().name == "2nd Level")
        {
            //Debug.Log("Loading 1st level");
            gameManager.LoadScene("1st Level");
        }
    }
}
