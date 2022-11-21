using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMotor : MonoBehaviour, IMove
{
    [Tooltip("Character Object")]
    [SerializeField] GameObject cha;

    public Transform shadow;
    Rigidbody2D rb;

    [SerializeField] Animator[] animators;

    IAttack<Health>[] attackScrpits;

    public float moveSpeed = 10f;

    void Start() {
        attackScrpits = GetComponents<IAttack<Health>>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // shadow shrinks when jumping
        float dist = Mathf.Abs(cha.transform.position.y - this.transform.position.y);
        float scale = dist / 0.4f;
        shadow.localScale = new Vector3(Mathf.Pow(1 / scale, 0.25f), Mathf.Pow(1 / scale, 0.25f), shadow.localScale.z);
    }

    public void Move(Vector2 direction) {
        // character movement
        if (direction.sqrMagnitude < .01f){
            rb.velocity = Vector2.zero;
            UpdateAnimations(direction.x, direction.y);
        }
        else
        {
            Vector2 dirnorm = direction.normalized * moveSpeed;
            dirnorm.y = dirnorm.y / 2;
            rb.velocity = dirnorm;
            // main character position correction
            cha.transform.position = new Vector3(this.transform.position.x, cha.transform.position.y, cha.transform.position.z);
            UpdateAnimations(direction.normalized.x, direction.normalized.y);
        }
    }

    public void UpdateAnimations(float horizontal, float vertical) {
        if (animators.Length > 0) {
            foreach (Animator a in animators) {
                a.SetFloat("HorizontalSpeed", horizontal);
                a.SetFloat("VerticalSpeed", vertical);
            }
        }

        if (attackScrpits.Length > 0)
        {
            foreach (IAttack<Health> attack in attackScrpits)
            {
                attack.SetDirection(new Vector2(horizontal, vertical).normalized);
            }
        }
    }
}
