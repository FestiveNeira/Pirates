using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public static bool isPlaying = false;
    private void Start()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if(musicObj.Length > 1)
        {
            Destroy(gameObject);
        }
        isPlaying = true;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(TypeWriterNewCutscene.musicStop == true)
        {
            isPlaying = false;
            Destroy(gameObject);
        }
    }
}
