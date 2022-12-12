using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScroller : MonoBehaviour
{
    Camera cam;
    public GameObject Outside;
    public GameObject Inside;
    public GameObject LoseZone;

    void Start() {
        cam = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayTracker"))
        {
            Outside.SetActive(true);
            Inside.SetActive(false);
            LoseZone.SetActive(true);
            cam.gameObject.GetComponent<SmoothCameraFollow>().follow = false;
            Destroy(gameObject);
        }
    }
}
