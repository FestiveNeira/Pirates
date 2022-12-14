using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSpawner : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        if(MenuMusic.isPlaying == false)
        {
            Instantiate(prefab, transform.position, transform.rotation);
        }
    }
}
