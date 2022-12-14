using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string scene;

    public AudioClip victory;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("PlayerHitbox")) {
            AudioSolver.instance.SwapTrack(victory);
            SceneManager.LoadScene(scene);
        }
    }
}
