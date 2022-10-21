using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    [Range(0f,2f)]
    public float radius = 2f;
    [Range(0f, 5f)]
    public float deformationStength = 0.5f;

    private Mesh mesh;
    private Vector3[] verticies, modifiedVerts;

    public Line line;
    Vector3 mouseStart;
    Vector3 mouseEnd;
    bool mouseDown;

    private void Start()
    {
        line = GameObject.FindObjectOfType<Line>();
        mesh = GetComponentInChildren<MeshFilter>().mesh;
        verticies = mesh.vertices;
        modifiedVerts = mesh.vertices;
    }

    void RecalculateMesh()
    {
        mesh.vertices = modifiedVerts;
        GetComponentInChildren<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
    }

    private void Update()
    {
       
        mouseDown = line.mouseDown;
       
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos.y);

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            for (int v = 0; v < modifiedVerts.Length; v++)

            {
                Vector3 distance = modifiedVerts[v] - hit.point;

                float smoothingFactor = 2f;
                float force = deformationStength / (1f + hit.point.sqrMagnitude);

                if(distance.sqrMagnitude < radius)
                {
                    if( mouseDown  )
                    {
                       // if( mousePos.x < -4f)
                      //  {
                            
                            modifiedVerts[v] = modifiedVerts[v] + (Vector3.down * force) / smoothingFactor;
                            
                           
                      //  }
                      //  else if(mousePos.x > 3.5)
                       // {
                       //     modifiedVerts[v] = modifiedVerts[v] + (Vector3.left * force) / smoothingFactor;
                       // }

                      //  if(mousePos.y < 0)
                       // {
                       //     modifiedVerts[v] = modifiedVerts[v] + (Vector3.up * force) / smoothingFactor;
                      //  }
                      //  else
                      //  {
                       //     modifiedVerts[v] = modifiedVerts[v] + (Vector3.down * force) / smoothingFactor;
                      //  }

                    }


                    


                }
            }
        }

        RecalculateMesh();
    }

  

 }

