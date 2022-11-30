using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEntity : MonoBehaviour
{
    Vector2 direction;
    public float projectileSpeed;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = (this.GetComponent<TargetPicker>().target.transform.position - this.transform.position);
        direction.Normalize();
        direction = new Vector2(direction.x * projectileSpeed, direction.y * projectileSpeed);
        Instantiate(projectile, this.transform.position, Quaternion.identity);
    }
}
