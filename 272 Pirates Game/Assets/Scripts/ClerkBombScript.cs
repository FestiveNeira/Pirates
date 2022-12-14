using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClerkBombScript : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();

    Rigidbody2D rb;
    public GameObject clerk;
    public Animator animator;
    public float destx;
    public Vector3 dir;
    
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
        // Explode and make a clerk at low hp
        if (this.transform.position.x <= destx) {
            foreach(GameObject e in currentCollisions) {
                if (e.gameObject.CompareTag("PlayerHitbox")) {
                    e.GetComponent<HealthPlayer>().TakeDamage(this.gameObject, 10);
                }
            }
            var temp = Instantiate(clerk, this.transform.position, Quaternion.Euler(Vector3.forward * 0));
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
    }
}
