using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleWithCam : MonoBehaviour
{
    Camera cam;
    float height;
    float width;
    public bool front;

    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        if (front) {
            this.gameObject.transform.localPosition = new Vector3(width / 2, 0, 0);
        }
        else {
            this.gameObject.transform.localPosition = new Vector3(-width / 2, 0, 0);
        }
    }
}
