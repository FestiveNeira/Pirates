using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePatchesSpecial : MonoBehaviour
{
    public Animator anim;

    public float maxenergy = 1;
    public float currentEnergy;

    public float timer = 0f;
    public float cooldown = 2.5f;

    public EnergyBar energyBar;

    public GameObject bullet;
    public int speed = 12;
    public float liveTime = 5f;

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

        GameObject bullet = BulletPool.Pool.GetPooledObject();
        if (bullet != null) {
            if (anim.transform.rotation.y != 0) {speed = -Mathf.Abs(speed);}
            else {speed = Mathf.Abs(speed);}

            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = Quaternion.Euler(0, anim.transform.rotation.y - 180, 0);
            bullet.GetComponent<BulletMove>().friendly = true;
            bullet.GetComponent<BulletMove>().speed = speed;
            bullet.GetComponent<BulletMove>().timetolive = liveTime;
            bullet.GetComponent<BulletMove>().timer = 0;
            bullet.SetActive(true);
        }
        else {
            currentEnergy = 1;
            energyBar.SetEnergy(currentEnergy);
        }
    }
}
