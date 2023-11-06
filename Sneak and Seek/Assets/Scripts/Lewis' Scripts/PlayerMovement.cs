using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    MasterInput controls;

    Rigidbody playerRB;

    public GameObject sprite;

    Vector3 movement;

    Vector2 stickInputData;

    public int speed;

    float timer;

    string state;
    string nextState;

    // Start is called before the first frame update
    void Start()
    {
        state = "Hidden";

        timer = 120;

        playerRB = GetComponent<Rigidbody>();

        controls = new MasterInput();

        controls.Enable();

        controls.Player.Movement.Enable();

        //sprite = GetComponentInChild<GameObject>();
    }

    // Is called when left stick on controller is used
    void OnMovement(InputValue stickInput)
    {
        //Debug.Log("Left stick input taken");
        
        // Processing input data for physics based movement
        stickInputData = stickInput.Get<Vector2>();
        sprite.transform.scale(new Vector3(stickInputData.x, 0f, stickInputData.y));
        movement = new Vector3(stickInputData.x, 0f, stickInputData.y);
    }

    void Seen()
    {
        timer = 120;
        state = "Seen";
        nextState = "Searching";
    }

    void Searching()
    {
        timer = 120;
        state = "Searching";
        nextState = "Hidden";
    }

    void Hidden()
    {
        timer = 120;
        state = "Hidden";
    }

    // Runs physics update for movement
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Mathf.RoundToInt(Time.deltaTime);
            if (timer == 0)
            {
                if (state == "Seen")
                {
                    Searching();
                }
                else if (state == "Searching")
                {
                    Hidden();
                }
            }
        }
        // Applying physics based movement
        playerRB.AddForce(movement * speed);
    }
}
