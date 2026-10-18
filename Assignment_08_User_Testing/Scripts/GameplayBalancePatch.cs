using UnityEngine;

/// <summary>
/// Practical 8: Gameplay Balance & Responsiveness Patch
/// Implements Coyote Time and Jump Buffering based on User Testing Feedback to eliminate dropped edge jumps.
/// </summary>
public class GameplayBalancePatch : MonoBehaviour
{
    [Header("Testing Iteration: Coyote Time & Jump Buffering")]
    [Tooltip("Grace period (seconds) allowing a jump after slipping off an edge.")]
    [SerializeField] private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    [Tooltip("Window (seconds) that remembers a jump press right before touching the ground.")]
    [SerializeField] private float jumpBufferTime = 0.15f;
    private float jumpBufferCounter;

    [Header("Component References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 13.5f;

    private bool isGrounded;

    public void UpdateGroundState(bool grounded)
    {
        isGrounded = grounded;
    }

    private void Update()
    {
        // 1. Coyote Time logic: reset timer when grounded, tick down in midair
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        // 2. Jump Buffer logic: store jump intent if pressed just before landing
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        // 3. Execute jump if both buffer and coyote counters are active
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            if (rb != null)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                Debug.Log("[Iteration 8 Applied] Buffered jump executed successfully via Coyote Time grace window!");
            }
            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        }
    }
}
