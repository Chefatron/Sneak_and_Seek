using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    float trans;

    // Used as a temporary transparency value that is changed on update to slowly fade the wall away
    float dynamicTrans;

    // Used to indicate that the transparency should gradually go back to 1 after the player exits
    bool resetTrans;

    // Will be used to find position of player
    Transform player;

    // Will be used to find position of wall
    Transform wall;

    // Start is called before the first frame update
    void Start()
    {
        wallRender = GetComponent<MeshRenderer>();

        trans = 0f;

        dynamicTrans = 1f;

        originalColourValue = wallRender.material.color;

        wall = GetComponent<Transform>();

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (resetTrans == true)
        {
            if (trans < 1)
            {
                trans = trans + 0.01f;

                // Sets the alpha value of the material based on trans
                colourValue = new Color(originalColourValue.r, originalColourValue.b, originalColourValue.g, trans);
                wallRender.material.SetColor("_Color", colourValue);
            }
            else if (trans > 1)
            {
                trans = 1f;
            }
            else if (trans == 1)
            {
                dynamicTrans = 1f;
                trans = 0f;
                resetTrans = false;
            }
        }
    }

    // Is called while player is in the parent objects trigger
    public void WallTransparency()
    {
        // Calculates how far behind the wall the player is
        //trans = player.position.z - wall.position.z;

        //trans = trans / 10;

        // Sets the transparency value to the absolute so we can avoid negatives
        //Mathf.Abs(trans);

        // Makes sure the transparency value doesn't go over 1 as that causes strange material bugs
        //if (trans > 1)
        //{
        //    trans = 1;
        //}

        // Rounds to 2 decimal points
        //trans = (Mathf.Round(trans * 100f) / 100f);

        // This if statement will simply set the wall to the distance based value of trans if dynamic trans has already equaled it, and if not it will adjust dynamic trans accordingly
        if (trans == dynamicTrans)
        {
            // Debug.Log("THEY ARE EQUAL");

            // Sets the alpha value of the material based on trans
            colourValue = new Color(originalColourValue.r, originalColourValue.b, originalColourValue.g, trans);
            wallRender.material.SetColor("_Color", colourValue);
        }
        else if (trans != dynamicTrans)
        {
            if (trans < dynamicTrans)
            {
                dynamicTrans = dynamicTrans - 0.01f;
            }
            else if (trans > dynamicTrans)
            {
                dynamicTrans = dynamicTrans + 0.01f;
            }

            // Rounds to 2 decimal points
            dynamicTrans = (Mathf.Round(dynamicTrans * 100f) / 100f);

            // Sets the alpha value of the material based on dynamic trans
            colourValue = new Color(originalColourValue.r, originalColourValue.b, originalColourValue.g, dynamicTrans);
            wallRender.material.SetColor("_Color", colourValue);
        }
    }

    // Resets the alpha of the wall
    public void ResetWall()
    {
        // Debug.Log("ResetWall has been called");

        resetTrans = true;
    }
}
