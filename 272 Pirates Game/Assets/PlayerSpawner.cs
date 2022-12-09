using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{  
    void Start()
    {
        Instantiate(PlayerManager.instance.currerntCharatcer.prefab, transform.position, Quaternion.identity);
    }
}
