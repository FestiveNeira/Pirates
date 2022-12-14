using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScroller : MonoBehaviour
{
    Camera cam;
    public GameObject Outside;
    public GameObject Inside;
    public GameObject LoseZone;
    public GameObject MovingCam;

    void Start() {
        cam = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayTracker"))
        {
            LVL1Music.isPlaying = false;
            Outside.SetActive(true);
            Inside.SetActive(false);
            LoseZone.SetActive(true);
            MovingCam.SetActive(true);
            cam.gameObject.GetComponent<SmoothCameraFollow>().follow = false;
            Destroy(gameObject);
        }
    }
}
