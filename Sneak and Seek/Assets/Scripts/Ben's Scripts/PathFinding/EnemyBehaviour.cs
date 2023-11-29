using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] GameObject playerLocation;
    public GameObject nodeMatrix;
    private GameObject[] nodeList;

    NavMeshAgent target;

    Vector3 lastKnownLocation;

    // == A bad thing ==
    Quaternion spriteRotation = Quaternion.Euler(45, 0, 0);
    //

    //
    bool changeTarget = false;

    public int enemyState;

    public float timerDuration;

    public int[] path;

    int targetNode;

    // Start is called before the first frame update
    void Start()
    {
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
        //Debug.Log(path[targetNode]);
        //Debug.Log(enemyState);
        
        GetComponentInChildren<SpriteRenderer>().transform.rotation = spriteRotation;

        stateChange();


    }

    private void OnTriggerStay(Collider trigger)
    {
        if (enemyState == 1)
        {
            Node temp = trigger.GetComponent<Node>();

            // Debug.Log("Trigger - " + temp.nodeID);
            // Debug.Log(path[targetNode]);

            // Debug.Log(temp.name);
            try
            {
                if (trigger.gameObject.tag == "Door (Enemy)")
                {
                    trigger.GetComponentInParent<DoorMove>().doorOpening = true;
                    trigger.GetComponentInParent<DoorMove>().doorClosing = false;
                }
            }
            catch (System.Exception)
            {

            }

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
            catch (System.Exception)
            {
                // Debug.Log("Ignore");
            }
        }
    }

    void OnTriggerExit(Collider trigger)
    {
        try
        {
            if (trigger.gameObject.tag == "Door (Enemy)")
            {
                trigger.GetComponentInParent<DoorMove>().doorOpening = false;
                trigger.GetComponentInParent<DoorMove>().doorClosing = true;

            }
        }
        catch (System.Exception)
        {

        }
    }

    private void stateChange()
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
                if (Mathf.RoundToInt(timerDuration) > 0)
                {
                    target.destination = transform.position;
                    timerDuration -= Time.deltaTime;
                    //Debug.Log(timerDuration);
                }
                else
                {
                    timerDuration = 15;
                    enemyState = 3;
                }

                break;

            case 3:     // Chasing
                if (Mathf.RoundToInt(timerDuration) > 0)
                {
                    target.destination = playerLocation.transform.position;

                    timerDuration -= Time.deltaTime;
                    //Debug.Log(timerDuration);
                }
                else
                {
                    if (playerLocation.GetComponent<PlayerHide>().Hidden == true)
                    {
                        lastKnownLocation = nodeList[GameObject.Find("Hiding spot (Active)").GetComponent<HideCheck>().nearestNodeID].transform.position;
                    }
                    else
                    {
                        lastKnownLocation = playerLocation.transform.position;
                    }
                    
                    enemyState = 4;
                    timerDuration = 5;
                }

                break;

            case 4:     // Searching
                if (Vector3.Distance(transform.position, lastKnownLocation) < 3) //transform.position.x == lastKnownLocation.x && transform.position.z == lastKnownLocation.z)
                {
                    if (Mathf.RoundToInt(timerDuration) > 0)
                    {
                        timerDuration -= Time.deltaTime;
                        //Debug.Log(timerDuration);
                    }
                    else
                    {
                        target.destination = nodeList[path[targetNode]-1].transform.position;
                        enemyState = 1;
                    }

                }

                break;

        }
    }


}

