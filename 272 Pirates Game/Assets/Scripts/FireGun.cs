using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    public GameObject parent;
    public GameObject target;
    public GameObject animparent;

    public bool isPlayer;
    public int speed = 12;
    public float liveTime = 5f;

    public float coolmax = 2f;
    float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = coolmax;
        if (parent.GetComponent<PlayerInputController>() != null) {
            isPlayer = true;
        }
        else {
            isPlayer = false;
        }
        if (parent.GetComponent<TargetPicker>().target != null) {
            target = parent.GetComponent<TargetPicker>().target;
        }
    }

    void FixedUpdate() {
        if (parent.GetComponent<TargetPicker>().target != null) {
            target = parent.GetComponent<TargetPicker>().target;
        }
        cooldown -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && cooldown <= 0) {
            GameObject bullet = BulletPool.Pool.GetPooledObject();
            if (bullet != null) {
                if (animparent.transform.rotation.y == 0) {speed = -Mathf.Abs(speed);}
                else {speed = Mathf.Abs(speed);}

                bullet.transform.position = this.transform.position;
                bullet.transform.rotation = animparent.transform.rotation;
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
