using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public GameObject parent;

    public int maxHealth = 100;
    public int currentHealth;

    public float IFrames = 1f;
    float immunitytimer = 0;

    public HealthBar healthBar;

    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void FixedUpdate() {
        if (immunitytimer > 0) {
            immunitytimer -= Time.deltaTime;
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            cam.GetComponent<MultipleTargetCamera>().targets.Remove(gameObject.transform);
            Destroy(parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && immunitytimer <= 0)
        {
            immunitytimer = IFrames;
            TakeDamage(10);
        }
    }
}
