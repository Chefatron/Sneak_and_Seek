using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FoV : MonoBehaviour
{
    // This are Important!! 
    // They do maths, within a callable function to make the rest of the code a little easier

    // This function covers a Vector3 into an angle.
    // It's used later on in the script to calculate the area of the FoV
    public static Vector3 GetVectorFromAngle(float angle)
    {
        float AngleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(AngleRad), 0, Mathf.Sin(AngleRad));
    }

    // This function takes an angle and converts it to a float
    // This is used later to calculate the location of the cursor on screen
    // and turns them into coordinates to determine the direction the character it facing

    // =============
    // NEEDS FIXING
    public static float GetAngleFromFloat(Vector3 dir) // Converts
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0)
        {
            n += 360;
        }

        return n;
    }
    // =============

    // setting up necessary variables

    // The layer mask is used later to determine what the rays should
    // collide with, for when we add bots/npcs
    [SerializeField] LayerMask LayerMask;

    private Mesh mesh;
    private Vector3 origin;
    private float StartingAngle;
    private float fov;

    // Start is called before the first frame update
    void Start()
    {
        // Setting up the mesh and setting some base variables
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 120f;                                 // The value of FoV is used to determine the angle in which the player can see, 360 meaning they can see everything
        origin = Vector3.zero;                      // This is just used to set a start locations, it changes with each update to follow the player
    }

    private void Update()
    {
        Debug.DrawRay(origin, GetVectorFromAngle(StartingAngle), Color.blue);
    }

    private void LateUpdate()
    {
        origin = Vector3.zero;                      // This is just used to set a start locations, it changes with each update to follow the player

        // More setting and assigning of variables
        int RayCount = 120;                         // The Raycount is used to determine how detailed the FoV is, the more rays, the more accurate the collisions are with objects
                                                    // However, the higher the raycount, the more taxing it is on the system so this may need optimising later on
        float Angle = StartingAngle;
        float AngleIncrease = fov / RayCount;       // This simple determines the increase needed between rays
        float ViewDistance = 15f;                    // The View Distance, as it suggests, determines the length of each ray and how far the player can view (will likely need adjusting to scale)

        Vector3[] vertices = new Vector3[RayCount + 1 + 1]; // +1 for the origin and +1 Ray 0
        Vector2[] uv = new Vector2[vertices.Length];        // this line is necessary, but I've got limited evidence as to why. Something to do with triangles and coordinates)
        int[] triangles = new int[RayCount * 3];            // This is used to store information involved with the dimensions of the triangle

        vertices[0] = origin;                       // This is set based on your characters current position (it regularly update and REQUIRES a player)

        int VertexIndex = 1;
        int TriangleIndex = 0;

        for (int i = 0; i <= RayCount; i++)
        {
            Vector3 vertex;   // This is used to determine the length of a ray
                              // in the event the ray collides with something
            RaycastHit hit;                                                                                                                                                                               // else it stores the the View Distance value

            

            if (Physics.Raycast(origin, GetVectorFromAngle(Angle), out hit, ViewDistance))
            {
                vertex = hit.point;

                Debug.Log(hit.point);
            }
            else
            {
                vertex = origin + GetVectorFromAngle(Angle) * ViewDistance;
            }


            vertices[VertexIndex] = vertex;

            if (i > 0)      // This just to prevent it throwing an error on the first cycle 
            {
                // This is necessary, trust me
                triangles[TriangleIndex + 0] = 0;
                triangles[TriangleIndex + 1] = VertexIndex - 1;
                triangles[TriangleIndex + 2] = VertexIndex;

                TriangleIndex += 3;
            }

            VertexIndex++;
            Angle -= AngleIncrease;
        }

        // This is necessary to build the mesh
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    // This is a callable function used in other scripts (best to be used in the movement script) to update the the origin point of the player
    // There's alternative ways of doing this, but this works so I'm not gonna change things
    public void SetOrigin(Vector3 newOrigin)
    {
        origin = newOrigin;
    }

    // This is used, once again externally, to update the direction in which it's MEANT to be facing
    // It's MEANT to face the mouse pointer (Will need updating to work with controller)
    // This needs fixing cos it doesn't work properly
    public void SetAimDirection(Vector3 AimDirection)
    {
        StartingAngle = GetAngleFromFloat(AimDirection) - fov / 2f;
    }
}
