using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject owner;
    public int speed;
    public float dist;
    Vector3 start;

    bool turn = false;

    void Start()
    {
        start = this.gameObject.transform.position;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(speed, 0, 0);
    }

    void Update()
    {
        if (getDist(this.gameObject.transform.position, start) > dist) {
            turn = true;
        }
        if (turn) {
            rb.velocity = (owner.transform.position - this.gameObject.transform.position).normalized * speed;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) {
            col.gameObject.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 1);
        }
        else if (GameObject.ReferenceEquals(col.gameObject.transform.parent.parent.parent.gameObject, owner)) {
            Destroy(gameObject);
        }
    }

    public float getDist(Vector3 a, Vector3 b) {
        return Mathf.Sqrt(Mathf.Pow((a - b).x, 2) + Mathf.Pow((a - b).y, 2));
    }
}
