using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float delay = 0.5f;
    public bool reset = true;

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

    void Attack()
    {
        //play attack animation
        anim.SetTrigger("Attack");

        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage enemies
        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.gameObject.CompareTag("Enemy"))
            {
                enemy.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 1);
            }
        }
    }

    public IEnumerator Recharge()
    {
        reset = false;
        anim.SetTrigger("Attack");

        //detect enemies
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //damage enemies
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                enemy.GetComponent<HealthEnemy>().TakeDamage(this.gameObject, 1);
            }
        }

        yield return new WaitForSeconds(delay);
        reset = true;
    }
}
