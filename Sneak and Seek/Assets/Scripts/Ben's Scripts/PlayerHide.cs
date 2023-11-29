using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    GameObject HidingPlace;
    [SerializeField] GameObject Smoke;
    CapsuleCollider Collider;
    SpriteRenderer PlayerSprite;

    Light candle;

    Vector3 ExitPosition;
    
    public bool Hidden;            // Given the slight change I made to the inputs and their functions, i needed a way
                                   // to avoid the method repeating and throwing too many errors :p 

    public bool playerSpotted;

    // As I found when testing the code without this, if you held the input, reagardless of if there was an object with the tag "Hiding spot (Active)"
    // it would still allow the player to go into the hidden state without actually hiding anywhere (Not what is meant to happen)
    private bool DoesTagExist(string tag)
    {
        // This is a function that checks whether an object with a certain tag exists in the current instance

        // In this case, it is used to check if an object with the tag "Hiding spot (Active)" exists (See line 54) 
        if (GameObject.FindGameObjectsWithTag(tag).Length == 0)
        {
            return false;
        } 
        else 
        { 
            return true; 
        }
        
    }

    private void Start()
    {
        Collider = GetComponent<CapsuleCollider>();

        // Storing information about the game objects that may need altering
        PlayerSprite = GetComponentInChildren<SpriteRenderer>();

        try
        {
            // Gets the light
            candle = GetComponentInChildren<Light>();
        }
        catch (System.Exception) { }
        

        // Sets the particle system to not active
        Smoke.SetActive(false);

        // Setting hidden to false
        Hidden = false;

        // The default state of not spotted
        playerSpotted = false;
    }

    // This is a function called when the player interacts with a hiding place
    void OnHide()
    {
        // This checks that the player isn't cureently in the hidden state already, as well
        // as making sure making sure their is an available hiding spot
        if (Hidden == false && DoesTagExist("Hiding spot (Active)") == true && playerSpotted == false && Time.timeScale == 1)
        {
            // This finds an 'activated' hiding spot (whenever the player is in a hiding spots 'HideTrigger' collider)
            HidingPlace = GameObject.FindGameObjectWithTag("Hiding spot (Active)");  

            // This stores the players locations prior to getting into the hiding spot (Used when the player leaves)
            ExitPosition = this.transform.position;

            // This makes the players sprite invisible
            PlayerSprite.gameObject.SetActive(false);
            Collider.enabled = false;

            try
            {
                // Turns of the players light while they hide
                candle.gameObject.SetActive(false);
            }
            catch(System.Exception) { }

            // This sets the players position to that of the object they're planning on hiding in
            this.transform.SetPositionAndRotation(HidingPlace.transform.position, this.transform.rotation);

            // Enables the particlr
            Smoke.SetActive(true);

            // Moves it to the position the player enters the hide from
            Smoke.transform.SetPositionAndRotation(ExitPosition, this.transform.rotation);

            // Plays it
            Smoke.GetComponent<ParticleSystem>().Play();

            // Updating the players Hidden status
            Hidden = true;
        }
        else if (Hidden == true && Time.timeScale == 1)
        {
            // This makes the players sprite visible
            PlayerSprite.gameObject.SetActive(true);
            Collider.enabled = true;

            // Turns the players light back on
            candle.gameObject.SetActive(true);

            // This sets the players position to that of the object they're planning on hiding in
            this.transform.SetPositionAndRotation(ExitPosition, transform.rotation);

            // Reattaches the particle to the player
            Smoke.transform.SetPositionAndRotation(transform.position, transform.rotation);

            // Disables the particle again
            Smoke.SetActive(false);

            // Updating the players Hidden state
            Hidden = false;
        }
    }

    //void OnUnHide()
    //{
    //    if (Hidden == true)
    //    {
    //        if (Time.timeScale == 1)
    //        {
    //            // This makes the players sprite visible
    //            PlayerSprite.gameObject.SetActive(true);
    //            Collider.enabled = true;

    //            // Turns the players light back on
    //            candle.gameObject.SetActive(true);

    //            // This sets the players position to that of the object they're planning on hiding in
    //            this.transform.SetPositionAndRotation(ExitPosition, transform.rotation);

    //            // Reattaches the particle to the player
    //            Smoke.transform.SetPositionAndRotation(transform.position, transform.rotation);

    //            // Disables the particle again
    //            Smoke.SetActive(false);

    //            // Updating the players Hidden state
    //            Hidden = false;
    //        }
            
            
    //    } 
    //}
}
