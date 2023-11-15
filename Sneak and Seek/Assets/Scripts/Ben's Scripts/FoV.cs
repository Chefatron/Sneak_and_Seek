using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoV : MonoBehaviour
{
    // == Declarations ==
    [SerializeField] float range;                       // 
    [SerializeField] float angle;                       // 
    [SerializeField] LayerMask layerMask;               // This allows us to pass though the layers in which the rays should interact with
    [SerializeField] int rayCount = 0;                  // This determines the number of rays making up the cone

    // == GameObjects ==

    Mesh visionConeMesh;                                // These are used when constructing the mesh
    MeshFilter meshFilter;                              // 

    // == Arrays == 

    int[] triangles;                                    //
    Vector3[] vertices;                                 //

    // == Variables ==

    float currentAngle;                                 //
    float angleIncrement;                               //
    public Vector3 playerLocation;                      //


    // Start is called before the first frame update
    void Start()
    {
        meshFilter = transform.GetComponent<MeshFilter>();      //
        visionConeMesh = new Mesh();                            // Gets the Mesh object
        angle = angle * Mathf.Deg2Rad;                          // Converts the angle to a radius
    }

    // Update is called once per frame
    void Update()
    {
        DrawFOV();
    }

    void DrawFOV()
    {
        triangles = new int[(rayCount - 1) * 3];        // Sets the size of the triangles array (stores all the points for each triangle within the FOV cone)
        vertices = new Vector3[rayCount + 1];           // Sets the size of the vertices array (can be loosely referred to as FOV resolution)
        vertices[0] = Vector3.zero;                     // Sets the rays origin point to (0, 0, 0)
        currentAngle = -angle / 2;                      // Sets the starting angle for the FoV (the negative is to apply a simple offset)
        angleIncrement = angle / (rayCount - 1);        // Sets angle difference between rays (it is inversely proportionate to the rayCount)

        for (int i = 0; i < rayCount; i++)
        {
            // == Doing Maths ==
            Vector3 raycastDirection = (transform.forward * Mathf.Cos(currentAngle)) + (transform.right * Mathf.Sin(currentAngle));     //
            Vector3 vertForward = (Vector3.forward * Mathf.Cos(currentAngle)) + (Vector3.right * Mathf.Sin(currentAngle));              //

            // == Firing Rays ==
            if (Physics.Raycast(transform.position, raycastDirection, out RaycastHit hitInfo, range, layerMask))                        // Fires a ray
            {
                vertices[i+1] = vertForward * hitInfo.distance;         // 

                if (hitInfo.collider.tag == "Player")
                {
                    playerLocation = hitInfo.point;

                    GetComponentInParent<EnemyBehaviour>().enemyState = 3;
                    GetComponentInParent<EnemyBehaviour>().timerDuration = 15;
                }
            }
            else
            {
                vertices[i + 1] = vertForward * range;                  // 
            }

            currentAngle += angleIncrement;                             // Adjusts the raycast angle
        }

        // ==  ==
        for (int i = 0, ii = 0; i < triangles.Length; i += 3, ii++)
        {
            triangles[i] = 0;               //
            triangles[i + 1] = ii + 1;      //
            triangles[i + 2] = ii + 2;      //
        }

        // ==  ==
        visionConeMesh.Clear();                 // Clears the previous mesh
        visionConeMesh.vertices = vertices;     //
        visionConeMesh.triangles = triangles;   //
        meshFilter.mesh = visionConeMesh;       // Applying the new cone mesh
    }
}
