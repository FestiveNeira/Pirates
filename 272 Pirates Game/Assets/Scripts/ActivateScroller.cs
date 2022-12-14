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

    public Object[] allObjects;
    List<GameObject> boats = new List<GameObject>();

    void Start() {
        allObjects = Resources.FindObjectsOfTypeAll(typeof(GameObject));
        cam = Camera.main;
        
        foreach (Object go in allObjects) {
            GameObject cGO = go as GameObject;
            if (cGO.CompareTag("Boat")) {
                Debug.Log("Boat Found");
                boats.Add(cGO);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayTracker"))
        {
            AudioSolver.instance.SwapTrack(chase);
            Outside.SetActive(true);
            Inside.SetActive(false);
            LoseZone.SetActive(true);
            MovingCam.SetActive(true);
            cam.gameObject.GetComponent<SmoothCameraFollow>().follow = false;
            foreach (GameObject boat in boats) {
                 boat.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
    }
}
