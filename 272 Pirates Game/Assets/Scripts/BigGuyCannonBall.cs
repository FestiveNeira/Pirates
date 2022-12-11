using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuyCannonBall : MonoBehaviour
{
    List<GameObject> currentCollisions = new List<GameObject>();

    Rigidbody2D rb;

    public Vector3 target;
    public float explodeY;
    public int strength;
    
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = target * strength;
    }

    void Update()
    {
        if (this.gameObject.transform.position.y > explodeY) {
            foreach(GameObject e in currentCollisions) {
                if (e.gameObject.CompareTag("Enemy")) {
                    e.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 10);
                }
            }
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
