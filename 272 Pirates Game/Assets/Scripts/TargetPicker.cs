using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPicker : MonoBehaviour
{
    public GameObject[] targets;
    public GameObject target;

    public bool randtarget = false;
    public bool isTarget = true;

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("PlayTracker");
        if (targets.Length != 0)
        {
            target = targets[0];
        }

        isTarget = true;
    }

    void Update()
    {
        if (targets.Length != 0) {
            if (randtarget)
            {
                int ind = Random.Range(0, targets.Length);
                bool isChar = false;
                foreach (GameObject t in targets)
                {
                    if (t != null)
                    {
                        isChar = true;
                    }
                }
                if (isChar)
                {
                    while (targets[ind] == null)
                    {
                        ind = Random.Range(0, targets.Length);
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
        else
        {
            targets = GameObject.FindGameObjectsWithTag("PlayTracker");
            if (targets.Length != 0)
            {
                target = targets[0];
            }

            isTarget = true;
        }
    }
}
