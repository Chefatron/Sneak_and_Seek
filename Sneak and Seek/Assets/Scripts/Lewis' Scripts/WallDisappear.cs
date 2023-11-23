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

    // Used to tell update to make the object's materials transparent
    bool makeTrans;

    // Start is called before the first frame update
    void Start()
    {
        wallRender = GetComponent<MeshRenderer>();

        trans = 0f;

        dynamicTrans = 1f;

        originalColourValue = wallRender.material.color;
    }

    // Update is called once per frame
    private void Update()
    {

        // Checks if the materials are to be made transparents
        if (makeTrans == true)
        {
            if (trans == dynamicTrans)
            {
                // Debug.Log("THEY ARE EQUAL");

                // Runs through all materials on the wall
                for (int i = 0; i < wallRender.materials.Length; i++)
                {
                    //Debug.Log(wallRender.materials[i].name);
                    if (wallRender.materials[i].name != "Skirt_material (Instance)")
                    {
                        // Sets the alpha value of the material based on trans
                        colourValue = new Color(originalColourValue.r, originalColourValue.b, originalColourValue.g, trans);
                        wallRender.materials[i].SetColor("_Color", colourValue);
                    }

                }

                // Sets make trans to false
                makeTrans = false;
            }
            else if (trans != dynamicTrans)
            {
                if (trans < dynamicTrans)
                {
                    dynamicTrans = dynamicTrans - 1f * Time.deltaTime;
                }
                else if (trans > dynamicTrans)
                {
                    dynamicTrans = dynamicTrans + 1f * Time.deltaTime;
                }

                // Rounds to 2 decimal points
                dynamicTrans = (Mathf.Round(dynamicTrans * 100f) / 100f);

                // Runs through all materials on the wall
                for (int i = 0; i < wallRender.materials.Length; i++)
                {
                    //Debug.Log(wallRender.materials[i].name);
                    if (wallRender.materials[i].name != "Skirt_material (Instance)")
                    {
                        // Sets the alpha value of the material based on dynamic trans
                        colourValue = new Color(originalColourValue.r, originalColourValue.b, originalColourValue.g, dynamicTrans);
                        wallRender.materials[i].SetColor("_Color", colourValue);
                        wallRender.materials[i].renderQueue = 3003;
                    }
                }
            }
        }

        // Checks if the materials of the walls are to be reset
        if (resetTrans == true)
        {

            if (trans < 1)
            {
                trans = trans + 1f * Time.deltaTime;

                // Runs through all materials on the wall
                for (int i = 0; i < wallRender.materials.Length; i++)
                {
                    if (wallRender.materials[i].name != "Skirt_material (Instance)")
                    {
                        // Sets the alpha value of the material based on trans
                        colourValue = new Color(originalColourValue.r, originalColourValue.b, originalColourValue.g, trans);
                        wallRender.materials[i].SetColor("_Color", colourValue);
                        wallRender.materials[i].renderQueue = 3001;
                    }
                }
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
        //Debug.Log("WallTransparnecy has been called");

        // Sets make trans to true so in update all of the materials on the object can be edited
        makeTrans = true;
    }

    // Resets the alpha of the wall
    public void ResetWall()
    {
        //Debug.Log("ResetWall has been called");

        resetTrans = true;
    }
}
