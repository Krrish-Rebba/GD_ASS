using UnityEngine;

/// <summary>
/// Practical 4: Physics Upgrade - Interactive Bouncy Springboard / Trampoline
/// Demonstrates Physics Material restitution combined with programmatic impulse forces.
/// </summary>
public class BouncySpringboard : MonoBehaviour
{
    [Header("Impulse Settings")]
    [Tooltip("Upward impulse force applied to the player or any dynamic physics body.")]
    [SerializeField] private float bounceImpulse = 18f;

    [Tooltip("Audio clip played when launched.")]
    [SerializeField] private AudioClip springSound;

    [Tooltip("Visual squash & stretch animation scale when compressed.")]
    [SerializeField] private Vector3 compressedScale = new Vector3(1.2f, 0.6f, 1f);

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the object landing on the spring has a Rigidbody2D
        Rigidbody2D rb = collision.rigidbody;
        if (rb != null)
        {
            // Only launch if the colliding body is landing from above
            if (collision.relativeVelocity.y <= 0f)
            {
                // Reset vertical velocity first to ensure consistent launch height
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

                // Apply instant upward impulse
                rb.AddForce(Vector2.up * bounceImpulse, ForceMode2D.Impulse);

                Debug.Log($"[Physics Practical 4] Springboard activated! Applied impulse {bounceImpulse} to {collision.gameObject.name}. Impact speed was {collision.relativeVelocity.magnitude:F2} m/s");

                if (springSound != null)
                {
                    AudioSource.PlayClipAtPoint(springSound, transform.position);
                }

                // Trigger squash animation
                StartCoroutine(SquashAnimation());
            }
        }
    }

    private System.Collections.IEnumerator SquashAnimation()
    {
        transform.localScale = compressedScale;
        yield return new WaitForSeconds(0.12f);
        transform.localScale = originalScale;
    }
}
