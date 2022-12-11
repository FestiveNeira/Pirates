using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public bool p1 = false;
    public bool p2 = false;
    public bool p3 = false;
    public bool p4 = false;
    void Start()
    {
        Instantiate(PlayerManager.instance.currerntCharatcer.prefab, transform.position, Quaternion.identity);
        if(PlayerManager.instance.currerntCharatcer.prefab.name == "Leader Player")
        {
            p1 = true;
        }
        if (PlayerManager.instance.currerntCharatcer.prefab.name == "Double Patches Player")
        {
            p2 = true;
        }
        if (PlayerManager.instance.currerntCharatcer.prefab.name == "Big Boy Player")
        {
            p3 = true;
        }
        if (PlayerManager.instance.currerntCharatcer.prefab.name == "Parrot Boy Player")
        {
            p4 = true;
        }
    }
}
