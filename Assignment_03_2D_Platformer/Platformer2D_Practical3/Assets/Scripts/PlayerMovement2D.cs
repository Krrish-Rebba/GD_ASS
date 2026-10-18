using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Practical 3: 2D Platformer Player Controller
/// Handles horizontal movement, jumping, and ground collision detection using Unity's Rigidbody2D.
/// Supports both the New Input System and Legacy Input.
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
        // 1. Read input (compatible with both New Input System and Legacy Input)
#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            float inputX = 0f;
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) inputX -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) inputX += 1f;
            horizontalInput = inputX;

            if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
            {
                jumpRequested = true;
            }
        }
        else
#endif
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                jumpRequested = true;
            }
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
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // 3. Apply jump impulse if requested
        if (jumpRequested)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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
