using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;

public class Node : MonoBehaviour
{
    GameObject hit;

    Vector3 direction;
    public int nodeID = 0;

    [SerializeField] int speed;
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
        direction = new Vector3 (0, 1, 0);

        //Ray ray = new Ray(this.transform.position, this.transform.forward);

        //
        for (int i = rayCount; i > 0; i--)
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);

            //
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 1000))
            {
                //Debug.Log("Hit" + hitInfo.collider.name);               // Testing

                if (hitInfo.collider.tag == "Nodes")
                {
                    //Debug.Log("Node found");    // Testing

                    //
                    int tempID = hitInfo.collider.gameObject.GetComponent<Node>().nodeID;

                    //Debug.Log(tempID);          // Testing

                    if (this.GetComponentInParent<ConnectionMatrix>().connectionMatrix[nodeID - 1, tempID - 1] == 0)
                    {
                        //
                        this.GetComponentInParent<ConnectionMatrix>().connectionMatrix[nodeID - 1, tempID - 1] = Mathf.RoundToInt(hitInfo.distance);
                    }
                }
                
            }

            transform.Rotate(0f, speed * angleChange * Time.deltaTime, 0f, Space.Self);
            //Debug.Log(speed * angleChange * Time.deltaTime);
        }

    }

    //void OnTriggerEnter(Collider collider)
    //{
    //    Debug.Log("Collision");

    //    if (collider.gameObject.tag == "Enemy")
    //    {
    //        Debug.Log("...with an enemy");

    //        //changeTarget = true;
    //    }
    //}

}
