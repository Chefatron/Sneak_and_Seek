using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AStarPathfinding : MonoBehaviour
{
    public GameObject nodeMatrix;
    private GameObject[] nodeList;

    NavMeshAgent target;

    bool changeTarget = false;

    int[] path = new int[4] {3, 8, 1, 6};

    int sourceNode;

    // Start is called before the first frame update
    void Start()
    {
        sourceNode = 0;

        target = GetComponent<NavMeshAgent>();

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
        if (changeTarget)
        {
            sourceNode++;

            if (sourceNode > path.Length - 1)
            {
                sourceNode = 0;
            }

            target.destination = nodeList[path[sourceNode]].transform.position;

            changeTarget = false;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Nodes")
        //{
        //    changeTarget = true;
        //}

        changeTarget = true;
    }
}
