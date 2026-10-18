using UnityEngine;

/// <summary>
/// Practical 4: Physics Upgrade - Dynamic Rolling Boulder / Physics Hazard
/// Demonstrates Rigidbody2D mass, linear/angular drag, physics materials, and collision impact callbacks.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class DynamicPhysicsHazard : MonoBehaviour
{
    [Tooltip("Impulse nudge force applied when pushed or released.")]
    [SerializeField] private float pushForce = 5f;

    [Tooltip("Particle effect or visual feedback on heavy impact.")]
    [SerializeField] private GameObject impactEffectPrefab;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float impactEnergy = collision.relativeVelocity.sqrMagnitude * rb.mass * 0.5f;

        Debug.Log($"[Physics Collision] Hazard '{gameObject.name}' struck '{collision.gameObject.name}'. " +
                  $"Relative Velocity: {collision.relativeVelocity.magnitude:F2} m/s | Kinetic Energy: {impactEnergy:F2} J");

        // If it strikes the player with high speed, apply damage or knockback
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
                knockbackDir.y = 0.5f; // Add slight upward pop
                playerRb.AddForce(knockbackDir * pushForce, ForceMode2D.Impulse);
                Debug.Log("[Physics Practical 4] Knocked back player with impulse!");
            }
        }
    }
}
