using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderSpecial : MonoBehaviour
{
    public Animator anim;

    public int maxenergy = 100;
    public int currentEnergy;
    public int energyCost = 25;

    public float coolmax = 2.5f;
    public float cooldown = 0;

    public EnergyBar energyBar;
    public bool usedSpecial = false;

    public List<GameObject> currentCollisions = new List<GameObject>();

    void Start()
    {
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        currentEnergy = maxenergy;
        energyBar.SetMaxEnergy(maxenergy);
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        anim.ResetTrigger("Special");
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(cooldown <= 0)
            {
                Recharge();
                currentEnergy -= energyCost;
                energyBar.SetEnergy(currentEnergy);
            }
        }
    }

    public void Recharge()
    {
        cooldown = coolmax;
        anim.SetTrigger("Special");

        //damage enemies
        for (int i = 0; i < currentCollisions.Count; i++)
        {
            if (currentCollisions[i].gameObject.CompareTag("Enemy"))
            {
                currentCollisions[i].GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 5);
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
