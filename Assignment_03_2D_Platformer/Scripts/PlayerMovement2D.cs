using UnityEngine;

/// <summary>
/// Practical 3: 2D Platformer Player Controller
/// Handles horizontal movement, jumping, and ground collision detection using Unity's Rigidbody2D.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovement2D : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("Horizontal movement speed in units per second.")]
    [SerializeField] private float moveSpeed = 8f;

    [Tooltip("Upward velocity applied when jumping.")]
    [SerializeField] private float jumpForce = 14f;

    [Header("Ground Detection")]
    [Tooltip("A child transform placed at the player's feet to detect ground contact.")]
    [SerializeField] private Transform groundCheckPoint;

    [Tooltip("Radius of the ground check sphere/circle.")]
    [SerializeField] private float groundCheckRadius = 0.2f;

    [Tooltip("Layer mask that represents walkable ground.")]
    [SerializeField] private LayerMask groundLayer;

    // References to cached components
    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isGrounded;
    private bool jumpRequested;

    private void Awake()
    {
        // Cache the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // Ensure rotation is locked along the Z-axis so the player doesn't tip over
        rb.freezeRotation = true;
    }

    private void Update()
    {
        // 1. Read input in Update (runs every rendered frame for crisp response)
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Returns -1 (A/Left), 0, or 1 (D/Right)

        // 2. Check if the Jump key (Spacebar) was pressed down
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        // 3. Optional: Flip sprite facing direction
        if (horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void FixedUpdate()
    {
        // Physics calculations must always run inside FixedUpdate for consistent simulation

        // 1. Check if the player is touching the ground
        if (groundCheckPoint != null)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        }
        else
        {
            // Fallback raycast directly below player collider if groundCheckPoint isn't assigned
            isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, groundLayer);
        }

        // 2. Apply horizontal velocity while preserving current vertical velocity (gravity/falling)
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // 3. Apply jump impulse if requested
        if (jumpRequested)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpRequested = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Draw a visual wire circle in the Scene view to help adjust groundCheckRadius
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}
