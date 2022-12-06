using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public bool friendly;
    public int speed;
    public float timetolive;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        if (friendly == null || speed == null || timetolive == null) {
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(speed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("EnemyRangedHit") && friendly)
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 10);
            gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("RangedHitbox") && !friendly)
        {
            if (collision.gameObject.GetComponent<HitCheck>().Check()) {
                collision.gameObject.transform.parent.gameObject.GetComponent<HealthPlayer>().TakeDamage(this.gameObject, 5);
            }
            gameObject.SetActive(false);
        }
    }
}
