using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    MasterInput controls;

    Rigidbody playerRB;

    PlayerHide Hiding;

    SpriteRenderer playerSprite;

    [SerializeField] Sprite upSprite;

    [SerializeField] Sprite downSprite;

    [SerializeField] Sprite leftSprite;

    [SerializeField] Sprite rightSprite;

    Vector3 movement;

    Vector2 stickInputData;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        playerSprite = GetComponentInChildren<SpriteRenderer>();

        controls = new MasterInput();

        controls.Enable();

        controls.Player.Movement.Enable();

        Hiding = GetComponent<PlayerHide>();
    }

    // Is called when left stick on controller is used
    void OnMovement(InputValue stickInput)
    {
        //Debug.Log("Left stick input taken");
        
        // Processing input data for physics based movement
        stickInputData = stickInput.Get<Vector2>();
        movement = new Vector3(stickInputData.x, 0f, stickInputData.y);
    }

    // Runs physics update for movement
    void FixedUpdate()
    {
        if (Hiding.Hidden == false)
        {
            // Applying physics based movement
            playerRB.AddForce(movement * speed);

            if (movement.z < 0f)
            {
                playerSprite.sprite = downSprite;
            }
            else if (movement.z > 0f)
            {
                playerSprite.sprite = upSprite;
            }
            else if (movement.x < 0f)
            {
                playerSprite.sprite = leftSprite;
            }
            else if (movement.x > 0f)
            {
                playerSprite.sprite = rightSprite;
            }
            else
            {
                playerSprite.sprite = downSprite;
            }
        }

    }
}
