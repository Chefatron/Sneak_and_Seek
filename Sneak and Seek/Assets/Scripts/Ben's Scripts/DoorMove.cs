using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    bool doorOpening;

    bool doorClosing;

    public bool doorIsOpen;

    float previousRotation;

    // Start is called before the first frame update
    void Start()
    {
        doorOpening = false;

        doorClosing = false;

        doorIsOpen = false;

        Debug.Log(Mathf.Sin(10f));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Mathf.Sin(10f));
        if (doorOpening == true && transform.localEulerAngles.y < 120)
        {
            Debug.Log("Door is opening");

            transform.Rotate(0, 30 * Time.deltaTime, 0);

            Debug.Log(transform.localEulerAngles.y - previousRotation);

            previousRotation = transform.localEulerAngles.y;
        }
        else if (transform.localEulerAngles.y >= 120)
        {
            transform.localEulerAngles.Set(0, 120, 0);

            doorOpening = false;

            doorIsOpen = true;
        }

        if (doorClosing == true && transform.localEulerAngles.y > 0)
        {
            Debug.Log("Door is closing");

            transform.Rotate(0, -30 * Time.deltaTime, 0);

            Debug.Log(transform.localEulerAngles.y - previousRotation);

            previousRotation = transform.localEulerAngles.y;
        }
        else if (transform.localEulerAngles.y <= 0)
        {
            transform.localEulerAngles.Set(0, 0, 0);

            doorClosing = false;

            doorIsOpen = false;
        }

    }

    public void openDoor()
    {
        Debug.Log("openDoor has been called");

        doorOpening = true;
    }

    public void closeDoor()
    {
        Debug.Log("closeDoor has been called");

        doorClosing = true;
    }
}
