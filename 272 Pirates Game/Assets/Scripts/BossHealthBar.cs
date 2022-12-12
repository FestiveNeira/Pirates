using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    /*public void SetMaxHealth(int health)
    {
        GameObject healthBar = GameObject.FindGameObjectWithTag("BossHealth");
        Slider slider = healthBar.GetComponent<Slider>();
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        GameObject healthBar = GameObject.FindGameObjectWithTag("BossHealth");
        Slider slider = healthBar.GetComponent<Slider>();
        slider.value = health;
    }*/

    public HealthEnemy eh;
    //public GameObject healthBar;

    private void Start()
    {
        GameObject healthBar = GameObject.FindGameObjectWithTag("BossHealth");
        Slider slider = healthBar.GetComponent<Slider>();
        slider.maxValue = eh.maxHealth;
        slider.value = eh.currentHealth;
    }

    void FixedUpdate()
    {
        GameObject healthBar = GameObject.FindGameObjectWithTag("BossHealth");
        Slider slider = healthBar.GetComponent<Slider>();
        slider.value = eh.currentHealth;
    }
}
