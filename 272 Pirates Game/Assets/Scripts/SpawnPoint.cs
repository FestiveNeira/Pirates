using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject clerk;
    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        Instantiate(clerk, this.transform);
        yield return new WaitForSeconds(0.5f);
        Instantiate(clerk, this.transform);
        yield return new WaitForSeconds(0.5f);
        Instantiate(clerk, this.transform);
        yield return new WaitForSeconds(0.5f);
        Instantiate(clerk, this.transform);
        yield return new WaitForSeconds(0.5f);
        Instantiate(clerk, this.transform);
    }
}
