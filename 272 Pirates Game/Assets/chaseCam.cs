using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseCam : MonoBehaviour
{
    Camera cam;
    public float height;
    public float width;
    
    void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, (height / 2) - 8, 0);
    }
}
