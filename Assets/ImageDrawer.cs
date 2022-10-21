using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageDrawer : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
            Renderer rend = go.GetComponent<Renderer>();
            rend.material.mainTexture = Resources.Load("rugTexture2") as Texture;

        }

    }


}
