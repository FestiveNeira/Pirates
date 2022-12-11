using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuySpecial : MonoBehaviour
{
    public Animator anim;

    public float maxenergy = 1;
    public float currentEnergy;

    public float timer = 0f;
    public float cooldown = 2.5f;

    public EnergyBar energyBar;

    public GameObject cannonBall;
    public int strength = 3;
    public GameObject parent;

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
        bool flipped = false;
        if (anim.transform.rotation.y != 0) {flipped = true;}

        //spawn cannon ball
        Vector3 initvelocity = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        initvelocity = new Vector3(Mathf.Abs(initvelocity.x), initvelocity.y, 0);
        var temp = Instantiate(cannonBall, this.transform.position, Quaternion.identity);
        temp.GetComponent<BigGuyCannonBall>().target = initvelocity.normalized;
        temp.GetComponent<BigGuyCannonBall>().explodeY = parent.transform.position.y;
        temp.GetComponent<BigGuyCannonBall>().strength = strength;
        temp.GetComponent<BigGuyCannonBall>().parent = parent;
        temp.GetComponent<BigGuyCannonBall>().flip = flipped;
    }
}
