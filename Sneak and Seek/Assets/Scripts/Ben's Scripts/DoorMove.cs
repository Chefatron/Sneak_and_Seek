using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    // Used to check and set the current state of the door
    public bool doorOpening;

    public bool doorClosing;

    public bool doorIsOpen;

    // Used to set whether this door is a locked door or not
    public bool isLocked;

    public bool isDoubleLocked;

    // Used to set which key corresponds to the door
    public int lockID;

    public int lock2ID;

    //Vector3 startRotation;

    // The collider for the door mesh
    BoxCollider doorCollider;

    Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        doorOpening = false;

        doorClosing = false;

        //startRotation = transform.localEulerAngles;

        //Debug.Log("Start rotation: " + startRotation.y);

        //Debug.Log("Start rotation plus 120: " + (startRotation.y + 120));

        // Sets the rotation of the door based on the state set in editor
        if (doorIsOpen == true)
        {
            doorAnimator.SetBool("Animate", true);
        }

        doorAnimator = GetComponent<Animator>();

        // Gets the collider then enables it
        doorCollider = GetComponentInChildren<BoxCollider>();
            
        doorCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if the door opening state is true and then if it is also less than or greater than 120 degrees rotation
        if (doorOpening == true)
        {
            doorAnimator.SetBool("Animate", true);

            doorOpening = false;

            doorIsOpen = true;
        }

        // Checks if the door closing state is true and then if it is also less than or greater than 0 degrees rotation
        if (doorClosing == true)
        {
            doorAnimator.SetBool("Animate", false);

            doorClosing = false;

            doorIsOpen = false;
        }

        if (!doorOpening && !doorClosing)
        {
            //GetComponentInChildren<BoxCollider>().isTrigger = false;

            doorCollider.enabled = true;
        }
    }

    // These are both self-explanatory
    public void openDoor()
    {
        //Debug.Log("openDoor has been called");

        doorOpening = true;

        doorCollider.enabled = false;
    }

    public void closeDoor()
    {
        //Debug.Log("closeDoor has been called");

        doorClosing = true;

        doorCollider.enabled = false;
    }
}
