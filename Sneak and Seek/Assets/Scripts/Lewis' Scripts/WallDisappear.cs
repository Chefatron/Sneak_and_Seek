using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDisappear : MonoBehaviour
{
    // Will be used to edit appearance of wall
    MeshRenderer wallRender;

    // Will be used to remember the original colour values of the wall
    Color originalColourValue;

    // Will be used to set the new colour values of the wall
    Color colourValue;

    // Will be used as the transparency value based on the players position
    public float trans;

    // Will be used to find position of player
    Transform player;

    // Will be used to find position of wall
    Transform wall;

    // Start is called before the first frame update
    void Start()
    {
        wallRender = GetComponent<MeshRenderer>();

        trans = 0f;

        originalColourValue = wallRender.material.color;

        wall = GetComponent<Transform>();

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Is called while player is in the parent objects trigger
    public void WallTransparency()
    {
        Debug.Log("FadeWall has been called");

        // Calculates how far behind the wall the player is
        trans = player.position.z - wall.position.z;

        trans = trans / 10;

        // Sets the transparency value to the absolute so we can avoid negatives
        Mathf.Abs(trans);

        // Makes sure the transparency value doesn't go over 1 as that causes strange material bugs
        if (trans > 1)
        {
            trans = 1;
        }

        // Assigns the old colour values and the new transparency value to our changing colour value
        colourValue = new Color (originalColourValue.r, originalColourValue.b, originalColourValue.g, trans);
        wallRender.material.SetColor("_Color", colourValue);
    }

    // Resets the alpha of the wall
    public void ResetWall()
    {
        Debug.Log("ResetWall has been called");

        wallRender.material.SetColor("_Color", originalColourValue);
    }
}
