using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotSpecial : MonoBehaviour
{
    public Animator anim;

    public float maxenergy = 1;
    public float currentEnergy;

    public float timer = 0f;
    public float cooldown = 2.5f;
    public bool hasBird = true;

    public EnergyBar energyBar;

    public GameObject parent;
    public GameObject bird;
    public int speed = 12;
    public float dist = 6f;

    public GameObject birdobj;

    void Start()
    {
        energyBar = GameObject.FindGameObjectWithTag("EnergyBar").GetComponent<EnergyBar>();
        currentEnergy = maxenergy;
        energyBar.SetMaxEnergy(maxenergy);
    }

    void Update()
    {
        if (birdobj.activeSelf != hasBird)
        {
            birdobj.SetActive(hasBird);
        }
        RechargeEnergy();
        anim.ResetTrigger("Special");
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(currentEnergy >= 1)
            {
                Recharge();
                hasBird = false;
                currentEnergy = 0;
                energyBar.SetEnergy(currentEnergy);
            }
        }
    }

    public void RechargeEnergy() {
        if (currentEnergy < 1 && hasBird) {
            timer += Time.deltaTime;
            if (timer > cooldown) {
                currentEnergy = 1;
            }
            else {
                currentEnergy = timer;
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
        if (anim.transform.rotation.y != 0) {speed = -Mathf.Abs(speed);}
        else {speed = Mathf.Abs(speed);}

        var temp = Instantiate(bird, this.transform.position, Quaternion.identity);

        temp.GetComponent<BirdMove>().origin = this;
        temp.GetComponent<BirdMove>().owner = parent;
        temp.GetComponent<BirdMove>().speed = speed;
        temp.GetComponent<BirdMove>().dist = dist;
        temp.SetActive(true);
    }
}
