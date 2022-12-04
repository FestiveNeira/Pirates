using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannons : MonoBehaviour
{
    public Animator animator;

    public GameObject[] manCannons;
    public float startattacktimer;
    public float attackDelay = 10f;

    public bool pointanim = true;

    // Start is called before the first frame update
    void Start()
    {
        startattacktimer = attackDelay;
        manCannons = GameObject.FindGameObjectsWithTag("Cannons");
    }

    // Update is called once per frame
    void Update()
    {
        startattacktimer -= Time.deltaTime;
        if (startattacktimer <= 2 && pointanim) {
            animator.SetTrigger("Point");
            pointanim = false;
        }
        if (startattacktimer <= 0) {
            for (int i = 0; i < manCannons.Length; i++) {
                manCannons[i].GetComponent<ShootEntity>().Fire();
            }
            startattacktimer = attackDelay;
            animator.ResetTrigger("Point");
            pointanim = true;
        }
    }
}
