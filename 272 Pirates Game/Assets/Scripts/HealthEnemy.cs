using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public GameObject parent;
    public Animator anim;

    public int knockback = 20;

    public int maxHealth = 5;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(GameObject source, int amount)
    {
        currentHealth -= amount;

        //play hurt animation prolly red flash

        //stop all movement and do knockback
        if (this.GetComponent<BasicMovement>() != null) {
            this.GetComponent<BasicMovement>().pause = true;
        }
        if (this.GetComponent<ManagerMovement>() != null) {
            this.GetComponent<ManagerMovement>().pause = true;
        }
        
        Vector3 dir = (this.transform.position - source.transform.position).normalized * knockback;
        this.GetComponent<Rigidbody2D>().velocity = dir;

        if (currentHealth <= 0)
        {
            GameManager.enemyCount -= 1;
            Lvl2GameManager.enemyCount -= 1;
            Destroy(parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Attack");
        }
    }
}