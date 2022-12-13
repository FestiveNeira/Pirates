using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl2GameManager : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;

    public GameObject spawn1;
    public GameObject spawn2;

    public GameObject p1HealthBar;
    public GameObject p2HealthBar;
    public GameObject p3HealthBar;
    public GameObject p4HealthBar;
    public PlayerSpawner ps;

    public int totalEnemies;

    public static int enemyCount;
    public static int playerCount;
    public static bool lvl2Dead = false;

    // Start is called before the first frame update
    void Start()
    {
        totalEnemies = (spawn1.GetComponent<SpawnPoint>().enemyTotal + spawn2.GetComponent<SpawnPoint>().enemyTotal);
        enemyCount = totalEnemies;

        if (ps.p1)
        {
            p1HealthBar.SetActive(true);
        }
        if (ps.p2)
        {
            p2HealthBar.SetActive(true);
        }
        if (ps.p3)
        {
            p3HealthBar.SetActive(true);
        }
        if (ps.p4)
        {
            p4HealthBar.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        spawn1.SetActive(true);

        if (enemyCount == (totalEnemies - (spawn1.GetComponent<SpawnPoint>().enemyTotal)))
        {
            wall1.SetActive(false);
            spawn2.SetActive(true);
        }

        if (enemyCount == (totalEnemies - (spawn1.GetComponent<SpawnPoint>().enemyTotal + spawn2.GetComponent<SpawnPoint>().enemyTotal)))
        {
            wall2.SetActive(false);
        }

        if (lvl2Dead == true)
        {
            lvl2Dead = false;
            SceneManager.LoadScene("DeathScene");
        }
    }
}