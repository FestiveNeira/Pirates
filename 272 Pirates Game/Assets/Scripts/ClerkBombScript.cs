using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClerkBombScript : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject clerk;
    public Animator animator;
    public float destx;
    public Vector3 dir;
    public GameObject[] targets;
    
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isProjectile", true);
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = dir;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= destx) {
            // Explode and make a clerk at low hp
            foreach (GameObject t in targets) {
                if (t.activeSelf && t != null) {
                    Vector2 v = this.transform.position - t.transform.position;
                    double dist = Mathf.Sqrt(Mathf.Pow(v.x, 2) + Mathf.Pow(v.y, 2));
                    if (dist < 1) {
                        // Damage t for (maxdmg - (maxdmg * dist))
                        t.transform.GetChild(0).gameObject.GetComponent<HealthPlayer>().TakeDamage(5);
                    }
                }
            }
            var temp = Instantiate(clerk, this.transform.position, Quaternion.Euler(Vector3.forward * 0));
            // alter temp.HP
            Destroy(gameObject);
        }
    }
}
