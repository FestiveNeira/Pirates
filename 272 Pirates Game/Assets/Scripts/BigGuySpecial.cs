using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuySpecial : MonoBehaviour
{
    public Animator anim;

    public GameObject parent;

    public int maxenergy = 100;
    public int currentEnergy;
    public int energyCost = 25;

    public float coolmax = 2.5f;
    public float cooldown = 0;

    public EnergyBar energyBar;
    public bool usedSpecial = false;

    public GameObject cannonBall;
    public int strength = 3;

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

        //spawn cannon ball
        Vector3 initvelocity = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        var temp = Instantiate(cannonBall, this.transform.position, Quaternion.identity);
        temp.GetComponent<BigGuyCannonBall>().target = initvelocity.normalized;
        temp.GetComponent<BigGuyCannonBall>().explodeY = parent.transform.position.y;
        temp.GetComponent<BigGuyCannonBall>().strength = strength;
    }
}
