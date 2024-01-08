using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody playerRB;

    PlayerHide Hiding;

    Vector3 movement;

    Vector2 stickInputData;

    [SerializeField] int speed;

    [SerializeField] Image staminaBar;

    // A multiplier to make the player faster when dashing
    int dashSpeed;

    // A variable used to store the time that the player cannot dash for
    float dashCooldown;

    // Used to time how long the player can dash
    float dashTimer;

    // Used to tell if the player is dashing
    bool isDashing; 

    [SerializeField] Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        Hiding = GetComponent<PlayerHide>();

        // Defualts to one or zero
        dashSpeed = 1;
        dashCooldown = 0f;
        dashTimer = 0f;
    }

    // Is called when left stick on controller is used
    void OnMovement(InputValue stickInput)
    {
        //Debug.Log("Left stick input taken");
       
        // Processing input data for physics based movement
        stickInputData = stickInput.Get<Vector2>();
        movement = new Vector3(stickInputData.x, 0f, stickInputData.y);

        playerAnimator.SetFloat("Move_X", stickInputData.x);
        playerAnimator.SetFloat("Move_Y", stickInputData.y);
    }

    void OnDash()
    {
        //Debug.Log("Dash has been called");

        // Checks if the player is moving, isn't hidden, and isn't in cooldown
        if ((stickInputData.x != 0f || stickInputData.y != 0f) && Hiding.Hidden == false && Time.unscaledTime > dashCooldown) 
        {
            dashSpeed = 2;

            isDashing = true;

            // Sets the 2 seconds timer
            dashTimer = Time.unscaledTime + 2f;

            //Debug.Log("Dash Timer ends: " + dashTimer);
        }
    }

    // Runs physics update for movement
    void FixedUpdate()
    {
        if (Hiding.Hidden == false)
        {
            // Applying physics based movement
            playerRB.AddForce(movement * speed * dashSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        //Debug.Log("Time is: " + Time.unscaledTime);

        if (isDashing == true)
        {
            // Checks if the dash timer is up, adjusts the bar if not
            if (Time.unscaledTime >= dashTimer)
            {
                dashSpeed = 1;

                // Adds a 7 second cooldown
                dashCooldown = Time.unscaledTime + 7f;

                //Debug.Log("Cooldown ends: " + dashCooldown);

                // Resets the timer
                dashTimer = 0f;

                isDashing = false;
            }
            else
            {
                staminaBar.fillAmount -= Time.unscaledDeltaTime / 2;
            }
        }
        else if (dashCooldown >= Time.unscaledTime)
        {
            staminaBar.fillAmount += Time.unscaledDeltaTime / 7;
        }


    }
}
