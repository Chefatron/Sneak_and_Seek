using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerHide : MonoBehaviour
{
    GameObject HidingPlace;
    CapsuleCollider Collider;
    MeshRenderer PlayerSprite;

    Vector3 ExitPosition;
    Color PlayerColor;      // This isn't actually used for a color, only to change the transparency :-) 

    bool Hidden;            // Given the slight change I made to the inputs and their functions, i needed a way
                            // to avoid the method repeating and throwing too many errors :p 


    // As I found when testing the code without this, if you held the input, reagardless of if there was an object with the tag "Hiding spot (Active)"
    // it would still allow the player to go into the hidden state without actually hiding anywhere (Not what is meant to happen)
    private bool DoesTagExist(string tag)
    {
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
        Collider = this.GetComponent<CapsuleCollider>();

        // Storing information about the game objects that may need altering
        PlayerSprite = GetComponentInChildren<MeshRenderer>();

        // Getting the sprites original color settings (The ONLY thing that changes SHOULD be the transparency) 
        PlayerColor = PlayerSprite.GetComponent<Color>();

        // Setting hidden to false
        Hidden = false;
    }

    // This is a function called when the player interacts with a hiding place
    void OnHide()
    {

        if (Hidden == false && DoesTagExist("Hiding spot (Active)") == true)
        {
            // This finds an 'activated' hiding spot (whenever the player is in a hiding spots 'HideTrigger' collider)
            HidingPlace = GameObject.FindGameObjectWithTag("Hiding spot (Active)");

            // This stores the players locations prior to getting into the hiding spot (Used when the player leaves)
            ExitPosition = this.transform.position;

            // This makes the players sprite invisible
            PlayerSprite.gameObject.SetActive(false);
            Collider.enabled = false;
            
            // This sets the players position to that of the object they're planning on hiding in
            this.transform.SetPositionAndRotation(HidingPlace.transform.position, this.transform.rotation);

            // Updating the players Hidden status
            Hidden = true;
        }
    }

    void OnUnHide()
    {
        if (Hidden == true)
        {
            // This makes the players sprite visible
            PlayerSprite.gameObject.SetActive(true);
            Collider.enabled = true;

            // This sets the players position to that of the object they're planning on hiding in
            this.transform.SetPositionAndRotation(ExitPosition, this.transform.rotation);

            // Updating the players Hidden state
            Hidden = false;
        } 
    }
}
