using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionMatrix : MonoBehaviour
{
    // Creates an empty 2D array used to store the available paths for each node
    public int[,] connectionMatrix;

    // Creates an empty array containing the child objects (nodes) within the matrix
    GameObject[] matrixNodes;

    // Stores the total number of nodes (chilren) available in the matrix
    int maxMatrixLength;

    // Start is called before the first frame update
    void Start()
    {
        //
        GameObject matrix = this.gameObject;

        //
        maxMatrixLength = matrix.transform.childCount;
        //Debug.Log(maxMatrixLength);                   // Testing - Outputs the max array length

        //
        matrixNodes = new GameObject[maxMatrixLength];
        //Debug.Log(matrixNodes.Length);                  // Testing - Outputs the number of registers child objects

        //
        connectionMatrix = new int[maxMatrixLength, maxMatrixLength];

        //
        for (int i = 0; i < matrixNodes.Length; i++)
        {
            matrixNodes[i] = matrix.transform.GetChild(i).gameObject;
        }

        // Testing section - Outputs the contents of nodeCount (array containing the nodes)
        //for (int i = 0; i < maxMatrixLength; i++)
        //{
        //    Debug.Log(matrixNodes[i].name);
        //}

        //
        for (int i = 0; i < maxMatrixLength; ++i)
        {
            matrixNodes[i].GetComponent<Node>().connectionMapping();
        }

        for (int i = 0; i < maxMatrixLength; i++)
        {
            for (int ii = 0; ii < maxMatrixLength; ii++)
            {
                if (connectionMatrix[i,ii] == 0)
                {
                    connectionMatrix[i,ii] = 999;
                }
            }
        }
        // Testing section - Checks the contents of the Connections Matrix
        //for (int i = 0; i < maxMatrixLength; i++)
        //{
        //    for (int j = 0; j < maxMatrixLength; j++)
        //    {
        //        if (i != j)
        //        {
        //            Debug.Log("Connection Matrix path " + i + "/" + j + " - " + connectionMatrix[i, j]);
        //        }
        //    }
        //}
    }

    

}
