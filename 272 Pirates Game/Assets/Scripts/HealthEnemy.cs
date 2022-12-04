using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public GameObject parent;
    public Animator anim;

    public int maxHealth = 5;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        //play hurt animation prolly red flash 

        if(currentHealth <= 0)
        {
            GameManager.enemyCount -= 1;
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
