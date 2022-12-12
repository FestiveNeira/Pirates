using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string scene;

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("PlayerHitbox")) {
            SceneManager.LoadScene(scene);
        }
    }
}
