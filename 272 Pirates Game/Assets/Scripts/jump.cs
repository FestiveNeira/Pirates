using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jump : MonoBehaviour
{
    //[SerializeField] private InputAction leap;

    Rigidbody2D rb;
    CapsuleCollider2D collider;

    [SerializeField] Animator animator;

    [Header("Jump Settings")]
    [Tooltip("How high can I jump")]
    public float jumpHeight = 4f;
    [Tooltip("How does gravity effect me while I am accending")]
    public float upGravityScale = 2f;
    [Tooltip("How does gravity effect me while I am falling")]
    public float downGravityScale = 3f;
    [Tooltip("Correct standing height")]
    public float fix = 0.8f;

    [Header("Ground Detection Options")]
    [Tooltip("Character's shadow object")]
    [SerializeField] GameObject shadow;

    public bool onGround = true;
    public bool jumped = false;
    public float jumppos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        jumppos = shadow.transform.position.y;

        //leap.performed += OnJumpPerformed;
    }

   /* public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        if (onGround && !jumped)
        {
            jumped = true;
            onGround = false;
            jumppos = shadow.transform.position.y;
        }
    }*/

    void Update()
    {
        // update in fringe cases
        if (gameObject.transform.position.y > (shadow.transform.position.y + (fix + 0.01)))
        {
            UpdateGravityScale();
        }
        // catch
        if (gameObject.transform.position.y < (shadow.transform.position.y + fix))
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            gameObject.transform.position = new Vector3(shadow.transform.position.x, shadow.transform.position.y + fix, gameObject.transform.position.z);
            onGround = true;
        }
        //jump
        if (onGround && !jumped && Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
            onGround = false;
            jumppos = shadow.transform.position.y;
        }
    }

    void FixedUpdate()
    {
        // correct character location based on movement while airborn
        if(!onGround)
        {
            UpdateGravityScale();
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (jumppos - shadow.transform.position.y), gameObject.transform.position.z);
            jumppos = shadow.transform.position.y;
        }
        else
        {
            gameObject.transform.position = new Vector3(shadow.transform.position.x, shadow.transform.position.y + fix, gameObject.transform.position.z);
        }
        // initialize jump
        if (jumped)
        {
            float jumpVel = Mathf.Sqrt(2 * upGravityScale * Mathf.Abs(Physics.gravity.y) * jumpHeight);
            rb.velocity = new Vector2(rb.velocity.x, jumpVel);
            jumped = false;
        }
        UpdateAnimations(!onGround);
    }

    void UpdateGravityScale()
    {
        // update gravity scale depending on if the character is moving up or down
        if (rb.velocity.y < -.01f)
        {
            rb.gravityScale = downGravityScale;
        }
        else
        {
            rb.gravityScale = upGravityScale;
        }
    }

    public void UpdateAnimations(bool jump) {
        animator.SetBool("Jump", jump);
    }
}
