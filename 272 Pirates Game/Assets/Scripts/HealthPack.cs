using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    public bool healing = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!healing)
        {
            if (collision.gameObject.CompareTag("PlayerHitbox"))
            {
                healing = true;
                Debug.Log("Heal");
                collision.gameObject.GetComponent<HealthPlayer>().Heal(30);
                Destroy(gameObject);
            }
        }
    }
}
