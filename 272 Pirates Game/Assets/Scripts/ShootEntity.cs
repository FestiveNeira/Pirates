using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEntity : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed;

    public float startattacktimer;
    public float randomattackdelay;
    public float maxDelay = 1f;
    public float attackDelay = 10f;
    bool dodelayticks = false;

    Vector3 direction;
    float degrees;

    // Start is called before the first frame update
    void Start()
    {
        startattacktimer = attackDelay;
        randomattackdelay = Random.Range(0f, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        startattacktimer -= Time.deltaTime;
        if (startattacktimer <= 0) {
            startattacktimer = attackDelay;
            dodelayticks = true;
        }
        if (dodelayticks) {
            randomattackdelay -= Time.deltaTime;
        }
        if (randomattackdelay <= 0) {
            direction = (this.GetComponent<TargetPicker>().target.transform.position - this.transform.position);
            direction.Normalize();
            direction = new Vector3(direction.x * projectileSpeed, direction.y * projectileSpeed, 0);

            degrees = 90 + (180/Mathf.PI) * Mathf.Asin((this.GetComponent<TargetPicker>().target.transform.position.x - this.transform.position.x) / Mathf.Sqrt(Mathf.Pow(this.GetComponent<TargetPicker>().target.transform.position.x - this.transform.position.x, 2) + Mathf.Pow(this.GetComponent<TargetPicker>().target.transform.position.y - this.transform.position.y, 2)));
            Quaternion q = Quaternion.Euler(Vector3.forward * degrees);
            var temp = Instantiate(projectile, this.transform.position, q);
            temp.GetComponent<ClerkBombScript>().destx = this.GetComponent<TargetPicker>().target.transform.position.x;
            temp.GetComponent<ClerkBombScript>().dir = direction;
            temp.GetComponent<ClerkBombScript>().targets = this.GetComponent<TargetPicker>().targets;
            randomattackdelay = Random.Range(0f, maxDelay);
            dodelayticks = false;
        }
    }
}
