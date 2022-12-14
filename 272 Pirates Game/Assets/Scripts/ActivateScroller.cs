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

    public AudioClip chase;

    void Start() {
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayTracker"))
        {
            AudioSolver.instance.SwapTrack(chase);
            Outside.SetActive(true);
            Inside.SetActive(false);
            LoseZone.SetActive(true);
            MovingCam.SetActive(true);
            cam.gameObject.GetComponent<SmoothCameraFollow>().follow = false;
            collision.gameObject.GetComponent<Boat>().boat.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
