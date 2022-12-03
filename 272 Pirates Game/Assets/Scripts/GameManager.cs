using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;

    public int totalEnemies = 40;

    public static int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyCount == 20)
        {
            wall1.SetActive(false);
            spawn1.SetActive(true);
            spawn2.SetActive(true);
        }

        if(enemyCount == 10)
        {
            wall2.SetActive(false);
            spawn3.SetActive(true);
            spawn4.SetActive(true);
        }

        if(enemyCount <= 0)
        {
            wall3.SetActive(false);
        }
    }
}
