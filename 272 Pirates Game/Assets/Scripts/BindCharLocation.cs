using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BindCharLocation : MonoBehaviour
{
    public float maxX = 128f;
    public float minX = -37f;
    public float maxY = -2.4f;
    public float minY = -7.5f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.transform.position);
        if (this.transform.position.y > maxY) {this.transform.position = new Vector2(this.transform.position.x, maxY);}
        if (this.transform.position.y < minY) {this.transform.position = new Vector2(this.transform.position.x, minY);}
        if (this.transform.position.x > maxX) {this.transform.position = new Vector2(maxX, this.transform.position.y);}
        if (this.transform.position.x < minX) {this.transform.position = new Vector2(minX, this.transform.position.y);}
    }
}
