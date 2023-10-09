using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    // This game object, the trigger
    GameObject trigger;

    // The child object, the wall/cube
    GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        // Assigns the trigger
        trigger = this.gameObject;

        // Uses the trigger to find the wall
        wall = trigger.transform.GetChild(0).gameObject;
    }

    // Is called when the trigger is entered
    private void OnTriggerStay(Collider other)
    {
        wall.GetComponent<WallDisappear>().WallTransparency();
    }

    // Is called when the trigger is exited
    private void OnTriggerExit(Collider other)
    {
        wall.GetComponent <WallDisappear>().ResetWall();
    }


}
