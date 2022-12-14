using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{

    //public AudioSource audi;

    public bool healing = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!healing)
        {
            if (collision.gameObject.CompareTag("PlayerHitbox"))
            {
                healing = true;
                collision.gameObject.GetComponent<HealthPlayer>().Heal(30);
                Destroy(gameObject);
                gameObject.GetComponent<AudioSource>().Play();
            }
            if (collision.gameObject.CompareTag("RangedHitbox"))
            {
                healing = true;
                collision.gameObject.transform.parent.gameObject.GetComponent<HealthPlayer>().Heal(30);
                Destroy(gameObject);
                gameObject.GetComponent<AudioSource>().Play();
            }
        }
    }
}
