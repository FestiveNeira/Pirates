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
                gameObject.GetComponent<AudioSource>().Play();
                collision.gameObject.GetComponent<HealthPlayer>().Heal(30);
                StartCoroutine(Sound());
            }
            if (collision.gameObject.CompareTag("RangedHitbox"))
            {
                healing = true;
                gameObject.GetComponent<AudioSource>().Play();
                collision.gameObject.transform.parent.gameObject.GetComponent<HealthPlayer>().Heal(30);
                StartCoroutine(Sound());
            }
        }
    }

    private IEnumerator Sound()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
