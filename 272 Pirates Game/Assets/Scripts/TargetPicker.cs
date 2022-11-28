using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPicker : MonoBehaviour
{
    public GameObject[] targets = new GameObject[4];
    public GameObject target;

    void Update()
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
                }
            }
        }
    }
}
