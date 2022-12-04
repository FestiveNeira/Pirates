using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    private Vector3 velocity;

    public float smoothTime = 0.5f;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiter = 50f;

    public float minY = -3.2f;
    public float maxY = 12.7f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistance()
    {
        Vector3 pos = new Vector3();
        foreach (Transform x in targets) {
            if (x != null) {
                pos = x.position;
                break;
            }
        }

        var bounds = new Bounds(pos, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null) {
                bounds.Encapsulate(targets[i].position);
            }
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        Vector3 pos = new Vector3();
        foreach (Transform x in targets) {
            if (x != null) {
                pos = x.position;
            }
        }

        var bounds = new Bounds(pos, Vector3.zero);
        for(int i = 0;  i < targets.Count; i++)
        {
            if (targets[i] != null) {
                bounds.Encapsulate(targets[i].position);
            }
        }

        return bounds.center;
    }
}
