using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuyCannonBall : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();

    Rigidbody2D rb;

    public GameObject parent;
    public bool flip;
    public Vector3 target;
    public float explodeY;
    public int strength;
    
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
            foreach(GameObject e in currentCollisions) {
                if (e.gameObject.CompareTag("Enemy")) {
                    e.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 10);
                }
            }
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);
        else if (col.gameObject.CompareTag("DestroyBulletObstacle")) {
            foreach(GameObject e in currentCollisions) {
                if (e.gameObject.CompareTag("Enemy")) {
                    e.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 10);
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
