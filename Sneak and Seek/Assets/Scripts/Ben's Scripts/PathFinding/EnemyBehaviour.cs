using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    GameObject playerLocation;
    public GameObject nodeMatrix;
    private GameObject[] nodeList;

    NavMeshAgent target;

    bool changeTarget = false;

    public int enemyState;

    public float timerDuration;

    public int[] path;

    int targetNode;

    // Start is called before the first frame update
    void Start()
    {
        playerLocation = GameObject.Find("Player");

        enemyState = 1;

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
        switch (enemyState)
        {
            case 1:     // Roaming
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
                break;

            case 2:     // Staring

                break;

            case 3:     // Chasing
                if (Mathf.RoundToInt(timerDuration) > 0)
                {
                    target.destination = playerLocation.transform.position;

                    timerDuration -= Time.deltaTime;
                    Debug.Log(timerDuration);
                }
                else
                {
                    enemyState = 4;
                    timerDuration = 5;
                }
                
                break;

            case 4:     // Searching
                if (Mathf.RoundToInt(timerDuration) > 0)
                {

                }
                else
                {
                    enemyState = 1;
                }
                break;
        }

    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (enemyState == 1)
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


}

