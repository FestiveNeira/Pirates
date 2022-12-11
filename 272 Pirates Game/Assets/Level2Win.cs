using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Win : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            // Go to next scene (Win)
        }
    }
}
