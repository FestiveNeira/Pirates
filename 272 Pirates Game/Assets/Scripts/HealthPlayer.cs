using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Animator anim;

    public HealthBar healthBar;

    [SerializeField] SpriteRenderer[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        StartCoroutine(FlashRed());

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(20);
        }
    }

    public IEnumerator FlashRed()
    {
        foreach(SpriteRenderer s in sprites)
        {
            s.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            s.color = Color.white;
        }
    }
}
