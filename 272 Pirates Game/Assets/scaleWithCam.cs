using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleWithCam : MonoBehaviour
{
    Camera cam;
    float height;
    float width;
    
    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
    }

    void Update()
    {
        
    }
}
