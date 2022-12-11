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
        Flip();
    }

    void Update()
    {
        if (getDist(this.gameObject.transform.position, start) > dist) {
            turn = true;
            Flip();
        }
        if (turn) {
            Vector3 temp = new Vector3(owner.transform.position.x, owner.transform.position.y + 1, 0);
            rb.velocity = (temp - this.gameObject.transform.position).normalized * Mathf.Abs(speed);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy")) {
            col.gameObject.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 1);
        }
        else if (GameObject.ReferenceEquals(col.gameObject.transform.parent.parent.parent.gameObject, owner) && turn) {
            Destroy(gameObject);
        }
    }

    public float getDist(Vector3 a, Vector3 b) {
        return Mathf.Sqrt(Mathf.Pow((a - b).x, 2) + Mathf.Pow((a - b).y, 2));
    }

    public void Flip() {
        if (this.gameObject.transform.rotation.y == 180) {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (this.gameObject.transform.rotation.y == 0) {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
