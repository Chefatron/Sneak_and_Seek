using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionMatrix : MonoBehaviour
{
    // Creates an empty 2D array used to store the available paths for each node
    int[] connectionMatrix[][];

    // Creates an empty array containing the child objects (nodes) within the matrix
    GameObject[] nodeCount[];

    // Stores the total number of nodes (chilren) available in the matrix
    int maxMatrixLength;

    // Start is called before the first frame update
    void Start()
    {
        maxMatrixLength = this.transform.childCount;

        nodeCount = new GameObject[maxMatrixLength];

        connectionMatrix[maxMatrixLength][maxMatrixLength];

        for (int i = 0; i < maxMatrixLength; i++)
        {
            nodeCount[i].this.transfrom.GetChild(i).gameObject;
            nodeCount[i].GetComponent<Node>().connectionMapping();
        }
    }

    
}
