using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMove
{
    [Tooltip("Character Object")]
    [SerializeField] GameObject character;
    [SerializeField] GameObject anichar;
    public Transform shadow;
    
    Rigidbody2D rb;
    Rigidbody2D crb;
    [SerializeField] Animator animator;

    public bool pause = false;
    public float pauselength = .1f;
    float pausetimer;

    IAttack<Health>[] attackScripts;

    public float moveSpeed = 10f;

    void Start() {
        attackScripts = GetComponents<IAttack<Health>>();
        rb = GetComponent<Rigidbody2D>();
        crb = character.GetComponent<Rigidbody2D>();
        pausetimer = pauselength;
    }

    void FixedUpdate()
    {
        // shadow shrinks when jumping
        float dist = Mathf.Abs(character.transform.position.y - this.transform.position.y);
        float scale = dist / 0.4f;
        shadow.localScale = new Vector3(Mathf.Pow(1 / scale, 0.25f), Mathf.Pow(1 / scale, 0.25f), shadow.localScale.z);
    }

    public void Move(Vector2 direction) {
        // character movement
        if (!pause) {
            Flip(direction.x);
            if (direction.sqrMagnitude < .01f){
                rb.velocity = Vector2.zero;
                crb.velocity = new Vector2(0, crb.velocity.y);
                UpdateAnimations(direction.x, direction.y);
            }
            else
            {
                Vector2 dirnorm = direction.normalized * moveSpeed;
                dirnorm.y = dirnorm.y / 2;
                rb.velocity = dirnorm;
                crb.velocity = new Vector2(dirnorm.x, crb.velocity.y);
                UpdateAnimations(Mathf.Abs(direction.normalized.x), Mathf.Abs(direction.normalized.y));
            }
            character.transform.position = new Vector3(this.transform.position.x, character.transform.position.y, this.transform.position.z);
        }
        else {
            pausetimer -= Time.deltaTime;
            if (pausetimer <= 0) {
                pause = false;
                pausetimer = pauselength;
            }
        }
    }

    public void UpdateAnimations(float horizontal, float vertical) {
        animator.SetFloat("Speed", horizontal + vertical);

        if (attackScripts.Length > 0)
        {
            foreach (IAttack<Health> attack in attackScripts)
            {
                attack.SetDirection(new Vector2(horizontal, vertical).normalized);
            }
        }
    }

    public void Flip(float x) {
        if (x < 0) {
            anichar.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (x > 0) {
            anichar.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
