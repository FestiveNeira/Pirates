using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRespawn : MonoBehaviour
{
    Camera cam;
    public float height;
    public float width;

    void Start() {
        cam = Camera.main;
        height = 2f * cam.orthographicSize;
        width = height * cam.aspect;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("PlayerHitbox")) {
            col.gameObject.GetComponent<HealthPlayer>().DoDamageNoKnockback(10);
            Vector3 playerLoc = col.gameObject.transform.parent.parent.transform.position;
            col.gameObject.transform.parent.parent.transform.position = new Vector3(playerLoc.x + (width / 2), playerLoc.y, 0);
        }
    }
}
