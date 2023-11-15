using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    // This game object, the trigger
    GameObject trigger;

    // The child object, the wall/cube
    //GameObject wall;
    
    // An array to hold all of the children attached to this trigger
    GameObject[] walls;

    // The amount of walls attached to this trigger
    int childAmount;

    // Start is called before the first frame update
    void Start()
    {
        // Assigns the trigger
        trigger = this.gameObject;

        // Uses the trigger to find the wall
        //wall = trigger.transform.GetChild(0).gameObject;

        // Gets the amount of children attached to the trigger and makes it an int
        childAmount = trigger.transform.childCount;

        // Tells the log how many children the trigger has
        //Debug.Log("Child amount is: " + childAmount);

        // Sets the length of the array to the amount of game objects
        walls = new GameObject[childAmount];

        // Assigns all of the children to a location in the array
        for (int i = 0; i < childAmount; i++)
        {
            // Sets the current iterations slot to the corresponding child 
            walls[i] = trigger.transform.GetChild(i).gameObject;
        }

        // Tells the log how long the array is now
        //Debug.Log("The length of walls is now: " + walls.Length);

        // Logs all of the gameObjects that were added to the array
        //for (int i = 0; i < childAmount; i++)
        //{
        //    Debug.Log(walls[i].gameObject.name);
        //}
    }



    // Is called when the trigger is entered
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Runs through the array and calls the function for each one
            for (int i = 0; i < childAmount; i++)
            {
                walls[i].GetComponent<WallDisappear>().WallTransparency();
            }
        }
    }

    // Is called when the trigger is exited
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Runs through the array and calls the function for each one
            for (int i = 0; i < childAmount; i++)
            {
                walls[i].GetComponent<WallDisappear>().ResetWall();
            }
        }
    }




}
