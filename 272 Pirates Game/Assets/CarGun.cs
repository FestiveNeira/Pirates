using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGun : MonoBehaviour
{
    public GameObject animparent;

    public bool isPlayer;
    public int speed = 12;
    public float liveTime = 5f;

    public float coolmax = 2f;
    float cooldown;

    void Start()
    {
        cooldown = coolmax;
    }

    void FixedUpdate() {
        cooldown -= Time.deltaTime;
    }

    void Update()
    {
        if (cooldown <= 0) {
            GameObject bullet = BulletPool.Pool.GetPooledObject();
            if (bullet != null) {
                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = Quaternion.Euler(0, animparent.transform.rotation.y - 180, 0);
                bullet.GetComponent<BulletMove>().friendly = isPlayer;
                bullet.GetComponent<BulletMove>().speed = speed;
                bullet.GetComponent<BulletMove>().timetolive = liveTime;
                bullet.GetComponent<BulletMove>().timer = 0;
                bullet.SetActive(true);
            }
            cooldown = coolmax;
        }
    }
}
