using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int nodeID = 0;

    int rayCount = 360;
    int angleChange;

    //
    void connectionMapping()
    {
        // Determines the incremental change in the rotation based on the rayCount
        angleChange = 360 / rayCount;

        //
        for (int i = rayCount; i < 0 ; i--)
        {
            //
            if(Raycast(this.origin, new Vector3(0,0,1), 100))
            {
                //
                if (this.GetComponentInParent<ConnectionMatrix>.connectionMatrix[nodeID][hitInfo.nodeID] != 1)
                {
                    //
                    this.GetComponentInParent<ConnectionMatrix>.connectionMatrix[nodeID][hitInfo.nodeID] = 1;
                }
            }

            this.transform.eulerAngles(new Vector3(0, angleChange, 0));
        }
    }
}
