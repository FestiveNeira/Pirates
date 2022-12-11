using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePatchesSpecial : MonoBehaviour
{
    public Animator anim;

    public int maxenergy = 100;
    public int currentEnergy;
    public int energyCost = 5;

    public float coolmax = 2.5f;
    public float cooldown = 0;

    public int speed = 12;
    public float liveTime = 5f;

    public EnergyBar energyBar;
    public bool usedSpecial = false;

    public GameObject bullet;

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

        GameObject bullet = BulletPool.Pool.GetPooledObject();
        if (bullet != null) {
            if (anim.transform.rotation.y == 0) {speed = -Mathf.Abs(speed);}
            else {speed = Mathf.Abs(speed);}

            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = anim.transform.rotation;
            bullet.GetComponent<BulletMove>().friendly = true;
            bullet.GetComponent<BulletMove>().speed = speed;
            bullet.GetComponent<BulletMove>().timetolive = liveTime;
            bullet.SetActive(true);
        }
        else {
            currentEnergy += energyCost;
            energyBar.SetEnergy(currentEnergy);
        }
    }
}
