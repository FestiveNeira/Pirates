using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public GameObject parent;

    public int knockback = 20;

    public int maxHealth = 100;
    public int currentHealth;

    public float IFrames = 1f;
    public float immunitytimer = 0;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start() {
        GameManager.playerCount += 1;
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate() {
        if (immunitytimer > 0) {
            immunitytimer -= Time.deltaTime;
        }
    }

    public void Heal(int amount)
    {
        if((amount + currentHealth) > 100)
        {
            currentHealth = 100;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            currentHealth += amount;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void TakeDamage(GameObject source, int damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        parent.gameObject.GetComponent<PlayerMovement>().pause = true;
        Vector3 dir = (parent.transform.position - source.transform.position).normalized * knockback;
        parent.gameObject.GetComponent<Rigidbody2D>().velocity = dir;
        
        if (currentHealth <= 0)
        {
            Destroy(parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Enemy") && immunitytimer <= 0)
        {
            immunitytimer = IFrames;
            TakeDamage(collision.gameObject, 10);
        }
    }

    private void OnDestroy() {
        GameManager.playerCount -= 1;
    }
}
