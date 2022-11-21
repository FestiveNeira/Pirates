using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Jump Settings")]
    [Tooltip("How high can I jump")]
    public float jumpHeight = 4f;
    [Tooltip("How does gravity effect me while I am accending")]
    public float upGravityScale = 2f;
    [Tooltip("How does gravity effect me while I am falling")]
    public float downGravityScale = 3f;

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

        if (shadow == null)
        {
            Debug.LogError(gameObject.name + "'s jump script is missing a shadow.");
        }
    }

    void Update()
    {
        // update in fringe cases
        if (gameObject.transform.position.y > (shadow.transform.position.y + 0.41))
        {
            UpdateGravityScale();
        }
        // catch
        if (gameObject.transform.position.y < (shadow.transform.position.y + 0.40))
        {
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            gameObject.transform.position = new Vector3(shadow.transform.position.x, shadow.transform.position.y + 0.4f, gameObject.transform.position.z);
            onGround = true;
        }
        // jump
        if (onGround && !jumped && Input.GetKeyDown(KeyCode.Space))
        {
            jumped = true;
            onGround = false;
            jumppos = shadow.transform.position.y;
        }
    }

    void FixedUpdate()
    {
        // correct character loctionn based on movement while airborn
        if(!onGround)
        {
            UpdateGravityScale();
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - (jumppos - shadow.transform.position.y), gameObject.transform.position.z);
            jumppos = shadow.transform.position.y;
        }
        else
        {
            gameObject.transform.position = new Vector3(shadow.transform.position.x, shadow.transform.position.y + 0.4f, gameObject.transform.position.z);
        }
        // initialize jump
        if (jumped)
        {
            float jumpVel = Mathf.Sqrt(2 * upGravityScale * Mathf.Abs(Physics.gravity.y) * jumpHeight);
            rb.velocity = new Vector2(rb.velocity.x, jumpVel);
            jumped = false;
        }
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
}
