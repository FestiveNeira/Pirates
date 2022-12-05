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

    public float minZoom = 12f;
    public float maxZoom = 8f;
    public float zoomLimiter = 10f;

    public float minY = -3.2f;
    public float maxY = 12.7f;

    private Camera cam;

    public float camhalfheight;

    public float zoom;
    public Vector3 position;

    float tiletozoomratio = (15.9f/12f);

    private void Start()
    {
        cam = GetComponent<Camera>();
        camhalfheight = (zoom*tiletozoomratio)/2;
    }

    private void LateUpdate()
    {
        camhalfheight = (zoom*tiletozoomratio)/2;
        if (targets.Count == 0)
            return;

        Move();
        Zoom();
    }

    void Zoom()
    {
        float t = GetGreatestDistance() / zoomLimiter;
        float newZoom = Mathf.Lerp(maxZoom, minZoom, t);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        zoom = cam.fieldOfView;
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        // get cam position
        Vector3 newPosition = centerPoint + offset;
        // fix camera to bottom of screen
        newPosition.y = (minY + camhalfheight) + offset.y;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        position = transform.position;
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
