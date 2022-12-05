using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
    public float thrust = 3;
    public float delay = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                //stop movement scripts
                Vector2 difference = (rb.transform.position - transform.position);
                difference = difference.normalized * thrust;
                rb.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(rb));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D rb)
    {
        if(rb != null)
        {
            yield return new WaitForSeconds(delay);
            rb.velocity = Vector2.zero;
            //resume movement scripts

        }
    } 
}
