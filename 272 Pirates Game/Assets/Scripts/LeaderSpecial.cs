using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeaderSpecial : MonoBehaviour
{
    public Animator anim;

    public float maxenergy = 1;
    public float currentEnergy;

    public float timer = 0f;
    public float cooldown = 2.5f;
    public int damage = 5;

    public EnergyBar energyBar;

    public List<GameObject> currentCollisions = new List<GameObject>();

    void Start()
    {
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        currentEnergy = maxenergy;
        energyBar.SetMaxEnergy(maxenergy);
    }

    void Update()
    {
        RechargeEnergy();
        anim.ResetTrigger("Special");
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(currentEnergy >= 1)
            {
                Recharge();
                currentEnergy = 0;
                energyBar.SetEnergy(currentEnergy);
            }
        }
    }

    public void RechargeEnergy() {
        if (currentEnergy < 1) {
            timer += Time.deltaTime;
            if (timer > cooldown) {
                currentEnergy = 1;
            }
            else {
                currentEnergy = timer / cooldown;
            }
            energyBar.SetEnergy(currentEnergy);
        }
        else {
            timer = 0;
        }
    }

    public void Recharge()
    {
        anim.SetTrigger("Special");

        //damage enemies
        foreach (GameObject e in currentCollisions.ToList())
        {
            if (e.gameObject.CompareTag("Enemy"))
            {
                e.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, damage);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
    }
}
