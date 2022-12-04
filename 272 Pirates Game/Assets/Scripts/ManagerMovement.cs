using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMovement : MonoBehaviour, IMove
{
    [Tooltip("Character Object")]
    [SerializeField] GameObject character;
    [SerializeField] GameObject anichar;
    public Transform shadow;

    Rigidbody2D rb;
    Vector2 destination;
    [SerializeField] Animator animator;

    IAttack<Health>[] attackScripts;

    public float moveSpeed = 10f;

    void Start() {
        attackScripts = GetComponents<IAttack<Health>>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (character.GetComponent<Cannons>().pointanim) {
            Vector2 direction = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
            direction.y = direction.y / 2;
            if (direction.sqrMagnitude > .01f) {
                rb.velocity = direction.normalized * moveSpeed;
                UpdateAnimations(Mathf.Abs(direction.normalized.x), Mathf.Abs(direction.normalized.y));
            }
            else {
                rb.velocity = Vector2.zero;
                UpdateAnimations(0, 0);
            }
            // regulate shadow size
            float dist = Mathf.Abs(character.transform.position.y - this.transform.position.y);
            float scale = dist / 0.4f;
            shadow.localScale = new Vector3(Mathf.Pow(1 / scale, 0.25f), Mathf.Pow(1 / scale, 0.25f), shadow.localScale.z);
        }
        else {
            rb.velocity = Vector2.zero;
            UpdateAnimations(0, 0);
        }
    }

    public void Move(Vector2 position) {
        destination = position;
        Flip();
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

    public void Flip() {
        if (rb.velocity.x < 0) {
            anichar.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rb.velocity.x > 0) {
            anichar.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
