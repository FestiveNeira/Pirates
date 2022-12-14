using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BigGuyCannonBall : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();

    Rigidbody2D rb;

    public GameObject parent;
    public bool flip;
    public Vector3 target;
    public float explodeY;
    public int strength;
    public int dmg;
    
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        float xvel = (target.x * strength * 2);
        if (flip) {xvel = -xvel;}
        float yvel = target.y * strength;
        if (yvel < 0) {yvel = 0;}
        rb.velocity = new Vector3(xvel, yvel, 0);
    }

    void Update()
    {
        if (this.gameObject.transform.position.y < explodeY) {
            foreach(GameObject e in currentCollisions.ToList()) {
                if (e.gameObject.CompareTag("Enemy")) {
                    e.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, dmg);
                }
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);
        if (col.gameObject.CompareTag("BulletObstacle")) {
            foreach(GameObject e in currentCollisions.ToList()) {
                if (e.gameObject.CompareTag("Enemy")) {
                    e.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, dmg);
                }
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
    }
}
