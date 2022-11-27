using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedMovement : MonoBehaviour, IMove
{
    [Tooltip("Character Object")]
    [SerializeField] GameObject character;
    public Transform shadow;

    Rigidbody2D rb;
    Vector2 destination;
    [SerializeField] Animator[] animators;

    IAttack<Health>[] attackScripts;

    public float moveSpeed = 10f;

    void Start() {
        attackScripts = GetComponents<IAttack<Health>>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = new Vector2(destination.x - transform.position.x, destination.y - transform.position.y);
        direction.y = direction.y / 2;
        if (direction.sqrMagnitude > .01f) {
            rb.velocity = direction.normalized * moveSpeed;
            UpdateAnimations(direction.normalized.x, direction.normalized.y);
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

    public void Move(Vector2 position) {
        destination = position;
    }

    public void UpdateAnimations(float horizontal, float vertical) {
        if (animators.Length > 0) {
            foreach (Animator a in animators) {
                a.SetFloat("HorizontalSpeed", horizontal);
                a.SetFloat("VerticalSpeed", vertical);
            }
        }

        if (attackScripts.Length > 0)
        {
            foreach (IAttack<Health> attack in attackScripts)
            {
                attack.SetDirection(new Vector2(horizontal, vertical).normalized);
            }
        }
    }
}
