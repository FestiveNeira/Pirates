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
        if (GameObject.FindGameObjectsWithTag("Player") != null)
        {
            targets = GameObject.FindGameObjectsWithTag("Player");
            DefaultTarget = targets[0];
            target = DefaultTarget;
        }
    }

    void Update()
    {
        if (randtarget)
        {
            int ind = Random.Range(0,4);
            while(!targets[ind].activeSelf) {
                ind = Random.Range(0,4);
            }
        }
        else
        {
            double temp = -1;
            foreach (GameObject t in targets)
            {
                if (t.activeSelf)
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
