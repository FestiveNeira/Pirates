using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;

    public int totalEnemies;

    public static int enemyCount;
    public static int playerCount;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = (spawn1.GetComponent<SpawnPoint>().enemyTotal + spawn2.GetComponent<SpawnPoint>().enemyTotal + spawn3.GetComponent<SpawnPoint>().enemyTotal + spawn4.GetComponent<SpawnPoint>().enemyTotal);
        enemyCount = totalEnemies;
    }

    // Update is called once per frame
    void Update()
    {
        spawn1.SetActive(true);
        
        if(enemyCount == (totalEnemies - (spawn1.GetComponent<SpawnPoint>().enemyTotal)))
        {
            wall1.SetActive(false);
            spawn2.SetActive(true);
        }

        if(enemyCount == (totalEnemies - (spawn1.GetComponent<SpawnPoint>().enemyTotal + spawn2.GetComponent<SpawnPoint>().enemyTotal)))
        {
            wall2.SetActive(false);
            spawn3.SetActive(true);
        }

        if(enemyCount <= (totalEnemies - (spawn1.GetComponent<SpawnPoint>().enemyTotal + spawn2.GetComponent<SpawnPoint>().enemyTotal + spawn3.GetComponent<SpawnPoint>().enemyTotal)))
        {
            wall3.SetActive(false);
            spawn4.SetActive(true);
        }

        if(playerCount <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
