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

    bool alternateTarget = false;
    bool changeTarget = false;

    int[] path;
    int sourceNode;


    int DijkstarAlgorithm(ConnectionMatrix connectionMatrix, int Nodes, int SourceNode, int targetNode)
    {
        int[] DistancePerNode = new int[Nodes];
        int[] PredictedWeightPerNode = new int[Nodes];
        int[] VisitedNodes = new int[Nodes];
        int Counter;
        int MinimumDistance;
        int NextNode = 0;

        int startNode, endNode;

        if(SourceNode > targetNode)
        {
            startNode = targetNode;
            endNode = SourceNode;
        }
        else
        {
            startNode = SourceNode;
            endNode = targetNode;
        }

        for (int i = startNode; i < endNode; i++)
        {
            DistancePerNode[i] = connectionMatrix.connectionMatrix[SourceNode, i];
            PredictedWeightPerNode[i] = SourceNode;
            VisitedNodes[i] = 0;
        }

        DistancePerNode[SourceNode] = 0;
        VisitedNodes[SourceNode] = 1;
        Counter = 1;

        while (Counter < (endNode - 1))
        {
            MinimumDistance = 999;

            for(int i = startNode; i < endNode; i++) 
            {
                if ((DistancePerNode[i] < MinimumDistance) && (VisitedNodes[i] == 0))
                {
                    MinimumDistance = DistancePerNode[i];
                    NextNode = i;
                }
            }

            VisitedNodes[NextNode] = 1;

            for (int i = startNode; i < endNode; i++)
            {
                if (VisitedNodes[i] == 0)
                {
                    if (MinimumDistance + connectionMatrix.connectionMatrix[NextNode, i] < DistancePerNode[i])
                    {
                        DistancePerNode[i] = MinimumDistance + connectionMatrix.connectionMatrix[NextNode, i];

                        PredictedWeightPerNode[i] = NextNode;
                    }
                }
            }

            Counter++;
        }

        return NextNode;
    }
    // Start is called before the first frame update
    void Start()
    {
        sourceNode = 0;

        path = new int[4] { 2, 6, 8, 3 };

        nodeList = new GameObject[nodeMatrix.transform.childCount];

        for (int i = 0; i < nodeMatrix.transform.childCount; i++)
        {
            nodeList[i] = nodeMatrix.transform.GetChild(i).gameObject;
        }

        target.destination = nodeList[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == nodeList[sourceNode].transform.position)
        {
            changeTarget = true;
        }

        if (!changeTarget)
        {
            target.destination = nodeList[DijkstarAlgorithm(_connectionMatrix, nodeList.Length, path[sourceNode], path[sourceNode + 1])].transform.position;
        }
        if (changeTarget) 
        {
            sourceNode++;

            if (sourceNode > 3)
            {
                sourceNode = 0;
            }
        }

    }
}
