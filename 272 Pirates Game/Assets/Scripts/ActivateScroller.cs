using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScroller : MonoBehaviour
{
    public GameObject Outside;
    public GameObject Inside;
    public GameObject LoseZone;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayTracker"))
        {
            Outside.SetActive(true);
            Inside.SetActive(false);
            LoseZone.SetActive(true);
            Destroy(gameObject);
        }
    }
}
