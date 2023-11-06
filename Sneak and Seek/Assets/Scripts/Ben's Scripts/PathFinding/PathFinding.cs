using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class PathFinding : MonoBehaviour
{
    public ConnectionMatrix _connectionMatrix;
    public GameObject nodeMatrix;
    private GameObject[] nodeList;

    NavMeshAgent target;

    //bool alternateTarget = false;
    bool changeTarget = false;

    int[,] connectionMatrix;
    int[] path;
    //public List<int> subPath;
    int sourceNode;


    int DijkstraAlgorithm(int[,] connectionMatrix, int Nodes, int SourceNode, int targetNode)
    {
        int[] DistancePerNode = new int[Nodes];
        int[] PredictedWeightPerNode = new int[Nodes];
        int[] VisitedNodes = new int[Nodes];
        int NodesInThePath;
        int Counter;
        int MinimumDistance;
        int NextNode = 0;

        //int startNode, endNode;

        //if(SourceNode > targetNode)
        //{
        //    startNode = targetNode;
        //    endNode = SourceNode;
        //}
        //else
        //{
        //    startNode = SourceNode;
        //    endNode = targetNode;
        //}

        // This loops through the possible moves within a single movement, and assigns each a 'difficulty' value
        for (int i = 0; i < Nodes; i++)
        {
            // Uses an array to store the 'difficulty' values
            DistancePerNode[i] = connectionMatrix[SourceNode, i];

            //
            //for (int ii = 0; ii < DistancePerNode.Length; ii++)
            //{
            //    Debug.Log(DistancePerNode[ii]);
            //}

            //
            PredictedWeightPerNode[i] = SourceNode;

            // Resets the visited nodes to allow for the algorithm to check all possible moves
            VisitedNodes[i] = 0;
        }

        // resets the source node's difficulty value to suggest it can't be done
        DistancePerNode[SourceNode] = 0;

        // Signifies the source node has been visited
        VisitedNodes[SourceNode] = 1;

        // increases the counter to accounts for the source node
        Counter = 1;


        //
        while (Counter < (Nodes - 1))
        {
            // sets a high value to mimic an 'impassable' state
            MinimumDistance = 9999;

            // loops through the possible moves and looks for the shortest possible movement (n)
            for (int i = 0; i < Nodes; i++)
            {
                if ((DistancePerNode[i] < MinimumDistance) && (VisitedNodes[i] == 0))
                {
                    MinimumDistance = DistancePerNode[i];
                    NextNode = i;
                }
            }

            // indicates that the shortest movement has been found
            VisitedNodes[NextNode] = 1;

            for (int i = 0; i < Nodes; i++)
            {
                
            }

            Counter++;
        }

        // This section is for debugging purposes, to check if the pathfinding actually works
        for (int i = 0; i < Nodes; i++)
        {
            if (i != sourceNode)
            {
                Debug.Log("Distance To Node" + i + " = " + DistancePerNode[i]);
                Debug.Log("The Path To The Destination Node Is: " + i);

                NodesInThePath = i;

                do
                {
                    NodesInThePath = PredictedWeightPerNode[NodesInThePath];
                    Debug.Log("<- " + NodesInThePath);
                } while (NodesInThePath != sourceNode);
            }
        }

        return 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Assigns an initial source value
        sourceNode = 0;

        // Assigns a sequence of nodes the character will loop through
        path = new int[4] { 2, 6, 8, 3 };

        // subPath length assignment

        // Gets the NavMeshAgent component, use in making the character move 
        target = GetComponent<NavMeshAgent>();

        // Getting all the Nodes in the scene and assigning them to an array. used to get the locations of where the character should move to
        nodeList = new GameObject[nodeMatrix.transform.childCount];

        for (int i = 0; i < nodeMatrix.transform.childCount; i++)
        {
            nodeList[i] = nodeMatrix.transform.GetChild(i).gameObject;
        }

        // Assigns the values to a local array to be used (should fix issue)

        connectionMatrix = new int[nodeList.Length, nodeList.Length];

        for (int i = 0; i < nodeList.Length; i++)
        {
            for (int ii = 0; ii < nodeList.Length; ii++)
            {
                connectionMatrix[i, ii] = _connectionMatrix.connectionMatrix[i, ii];
            }
        }

        // Add something to initially find the closest node (can also be used later to have the AI return to its loop)

        // Assigns the character an initial node to walk to
        target.destination = nodeList[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeTarget)
        {
            sourceNode++;

            if (sourceNode > 3)
            {
                sourceNode = 0;
            }

            DijkstraAlgorithm(connectionMatrix, nodeList.Length, path[sourceNode], path[sourceNode + 1]);

            changeTarget = false;
        }
        //target.destination = nodeList[].transform.position;
    }

    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Collision");

        if (collider.gameObject.tag == "Nodes")
        {
            //Debug.Log("...with a node");

            changeTarget = true;
        }
    }

}
