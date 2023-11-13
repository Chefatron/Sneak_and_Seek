using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AStarPathfinding : MonoBehaviour
{
    public GameObject nodeMatrix;
    private GameObject[] nodeList;
    public FoV fieldOfView;
    public GameObject Enemy;

    NavMeshAgent target;

    bool changeTarget = false;

    public int[] path;

    int targetNode;

    // Start is called before the first frame update
    void Start()
    {
        targetNode = 0;

        target = GetComponent<NavMeshAgent>();

        nodeList = new GameObject[nodeMatrix.transform.childCount];

        for (int i = 0; i < nodeMatrix.transform.childCount; i++)
        {
            nodeList[i] = nodeMatrix.transform.GetChild(i).gameObject;
        }

        target.destination = nodeList[path[0] - 1].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (changeTarget)
        {
            targetNode++;

            if (targetNode > path.Length - 1)
            {
                targetNode = 0;
            }

            target.destination = nodeList[path[targetNode] - 1].transform.position;

            changeTarget = false;
        }

        //fieldOfView.SetOrigin(Enemy.transform.position);
        fieldOfView.SetAimDirection(Enemy.transform.forward);
    }

    private void OnTriggerEnter(Collider trigger)
    {
        Node temp = trigger.GetComponent<Node>();

        // Debug.Log("Trigger - " + temp.nodeID);
        // Debug.Log(path[targetNode]);

        // Debug.Log(temp.name);

        try
        {
            if (temp.nodeID != path[targetNode])
            {
                // Debug.Log("Ignore");
            }
            else
            {
                // Debug.Log("State changed");

                changeTarget = true;
            }
        }
        catch (System.Exception ex)
        {
            // Debug.Log("Ignore");
        }
    }
}

