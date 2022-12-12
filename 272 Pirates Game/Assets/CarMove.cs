using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float maxY = -0.5f;
    public float minY = -5.25f;

    bool down = true;

    void FixedUpdate()
    {
        if (down) {
            float temp = this.gameObject.transform.position.y - 0.05f;
            if (temp >= minY) {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, temp, 0);
            }
            else {
                down = false;
            }
        }
        else {
            float temp = this.gameObject.transform.position.y + 0.05f;
            if (temp <= maxY) {
                this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, temp, 0);
            }
            else {
                down = true;
            }
        }
    }
}
