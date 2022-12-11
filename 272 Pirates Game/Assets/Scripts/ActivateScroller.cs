using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScroller : MonoBehaviour
{
    public GameObject scroller;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            scroller.SetActive(true);
        }
    }
}
