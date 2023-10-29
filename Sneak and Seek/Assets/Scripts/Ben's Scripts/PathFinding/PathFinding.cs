using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinding : MonoBehaviour
{
    public GameObject nodeMatrix;
    private GameObject[] nodeList;
    public int[] path;
    NavMeshAgent target;
    bool alternateTarget;

    // Start is called before the first frame update
    void Start()
    {
        nodeList = new GameObject[nodeMatrix.transform.childCount];
        path = new int[] { 2, 7, 9, 4 };                                // The list value will have to be one higher than the actual ID to account for the array starting at 0
    }

    // Update is called once per frame
    void Update()
    {
        if (alternateTarget!)
        {
            Target.destination = nodeList[];
        }
    }
}
