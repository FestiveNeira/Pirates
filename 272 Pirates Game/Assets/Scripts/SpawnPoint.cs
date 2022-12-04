using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] enemyList;
    public int[] enemyCount;

    public int enemyTotal = 0;

    private void OnEnable()
    {
        for (int i = 0; i < enemyCount.Length; i++) {
            enemyTotal += enemyCount[i];
        }
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < enemyList.Length; i++) {
            for (int o = 0; o < enemyCount[i]; o++) {
                Instantiate(enemyList[i], this.transform);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
