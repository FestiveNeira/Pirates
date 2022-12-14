using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    Camera cam;
    public float height;
    public float width;

    public Transform target;
    public Vector3 offset;
    public float damping = 0.5f;

    private Vector3 velocity = Vector3.zero;

    public bool follow = true;

    private void Start()
    {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    private void FixedUpdate()
    {
        if (follow) {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
        else {
            target = GameObject.FindGameObjectWithTag("ChaseTarget").transform;
        }
        Vector3 movePosition = target.position + offset;
        if (movePosition.y - (height / 2) < -8) {
            movePosition.y = -(8 - (height / 2));
        }
        transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocity, damping);
    }
}
