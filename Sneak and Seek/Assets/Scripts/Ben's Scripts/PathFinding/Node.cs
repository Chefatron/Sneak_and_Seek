using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Node : MonoBehaviour
{
    GameObject hit;

    Vector3 direction;
    public int nodeID = 0;

    int rayCount;
    int angleChange;

    //
    public void connectionMapping()
    {
        //
        rayCount = 360;

        // Determines the incremental change in the rotation based on the rayCount
        angleChange = 360 / rayCount;
        //Debug.Log(angleChange);                         // Testing

        //
        direction = new Vector3 (0, angleChange, 0);

        Ray ray = new Ray(this.transform.position, this.transform.forward);

        //
        for (int i = rayCount; i > 0; i--)
        {
            //
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
            {
                Debug.Log("Hit" + hitInfo.collider.name);               // Testing

                if (hitInfo.collider.tag == "Nodes")
                {
                    Debug.Log("Node found");    // Testing

                    //
                    int tempID = hitInfo.collider.gameObject.GetComponent<Node>().nodeID;

                    Debug.Log(tempID);          // Testing

                    if (this.GetComponentInParent<ConnectionMatrix>().connectionMatrix[nodeID, tempID] == 0)
                    {
                        //
                        this.GetComponentInParent<ConnectionMatrix>().connectionMatrix[nodeID, tempID] = Mathf.RoundToInt(hitInfo.distance);
                    }
                }
                
            }

            //float angle = rayCount * Mathf.Rad2Deg;
            transform.Rotate(1 * direction);
        }

    }

}
