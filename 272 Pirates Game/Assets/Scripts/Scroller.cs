using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float speed = 10;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
