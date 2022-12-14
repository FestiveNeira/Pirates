using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1Music : MonoBehaviour
{
    public static bool isPlaying = true; 

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
