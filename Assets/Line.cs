using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Line : MonoBehaviour
{
    int vertexCount = 0;
    public bool mouseDown = false;
    LineRenderer line;
    public Vector3 mouseStart;
    public Vector3 mouseEnd;
    public bool touchedSponge = false;

   


    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }



    [System.Obsolete]
    private void Update()
    {
            if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {

                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    line.SetVertexCount(vertexCount + 1);
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    line.SetPosition(vertexCount, mousePos);
                    vertexCount++;

                    BoxCollider box = gameObject.AddComponent<BoxCollider>();
                    box.transform.position = line.transform.position;
                    box.size = new Vector2(0.1f, 0.1f);
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    vertexCount = 0;
                    line.SetVertexCount(0);
                    //each collider in this array, we are storing that in this box variable
                    //and then we are destroying that.
                    BoxCollider[] colliders = GetComponents<BoxCollider>();
                    foreach (BoxCollider box in colliders)
                    {
                        Destroy(box);
                    }
                }
            }
        }

        //else if(Application.platform == RuntimePlatform.WindowsPlayer)
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                mouseStart = Input.mousePosition;
                mouseDown = true;
            }

            if (mouseDown)
            {
                line.SetVertexCount(vertexCount + 1);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                line.SetPosition(vertexCount, mousePos);
                vertexCount++;

                BoxCollider box = gameObject.AddComponent<BoxCollider>();
                box.transform.position = line.transform.position;
                box.size = new Vector2(0.1f, 0.1f);
            }
            if (Input.GetMouseButtonUp(0))
            {
                mouseEnd = Input.mousePosition;
                mouseDown = false;
                vertexCount = 0;
                line.SetVertexCount(0);
                //each collider in this array, we are storing that in this box variable
                //and then we are destroying that.
                BoxCollider[] colliders = GetComponents<BoxCollider>();
                foreach (BoxCollider box in colliders)
                {
                    Destroy(box);
                }
            }
        }
    }

    

}