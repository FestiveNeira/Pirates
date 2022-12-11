using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotSpecial : MonoBehaviour
{
    public Animator anim;

    public GameObject parent;

    public int maxenergy = 100;
    public int currentEnergy;
    public int energyCost = 10;

    public float coolmax = 2.5f;
    public float cooldown = 0;

    public int speed = 12;
    public float dist = 6f;

    public EnergyBar energyBar;
    public bool usedSpecial = false;

    public GameObject bird;

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
        if (anim.transform.rotation.y == 0) {speed = -Mathf.Abs(speed);}
        else {speed = Mathf.Abs(speed);}

        var temp = Instantiate(bird, this.transform.position, Quaternion.identity);

        bird.GetComponent<BirdMove>().owner = parent;
        bird.GetComponent<BirdMove>().speed = speed;
        bird.GetComponent<BirdMove>().dist = dist;
        bird.SetActive(true);
    }
}
