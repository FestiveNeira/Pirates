using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    public float delay = 0.5f;
    public bool reset = true;

    public List<GameObject> currentCollisions = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        anim.ResetTrigger("Attack");
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(reset)
            {
                StartCoroutine(Recharge());
            }
        }


    }

    public IEnumerator Recharge()
    {
        reset = false;
        anim.SetTrigger("Attack");

        //damage enemies   (GameObject enemy in currentCollisions)
        for (int i = 0; i < currentCollisions.Count; i++)
        {
            if (currentCollisions[i].gameObject.CompareTag("Enemy"))
            {
                currentCollisions[i].GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 1);
            }
        }

        yield return new WaitForSeconds(delay);
        reset = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add(col.gameObject);
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove(col.gameObject);
        foreach (GameObject gObject in currentCollisions)
        {
            print(gObject.name);
        }
    }
}
