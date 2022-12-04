using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPicker : MonoBehaviour
{
    public GameObject[] targets = new GameObject[4];
    public GameObject DefaultTarget;
    public GameObject target;

    public bool randtarget = false;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("PlayTracker") != null)
        {
            targets = GameObject.FindGameObjectsWithTag("PlayTracker");
            DefaultTarget = targets[0];
            target = DefaultTarget;
        }
    }

    void Update()
    {
        if (randtarget)
        {
            int ind = Random.Range(0,4);
            if (targets[0] != null || targets[1] != null || targets[2] != null || targets[3] != null) {
                while (targets[ind] == null) {
                    ind = Random.Range(0,4);
                }
            }
            target = targets[ind];
        }
        else
        {
            double temp = -1;
            foreach (GameObject t in targets)
            {
                if (t != null && t.activeSelf)
                {
                    double dist = (transform.position - t.transform.position).sqrMagnitude;
                    if(temp == -1 || dist < temp)
                    {
                        target = t;
                        temp = dist;
                    }
                }
            }
        }
    }
}
