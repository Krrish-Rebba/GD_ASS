using System.Collections;
using UnityEngine;

/// <summary>
/// Practical 4: Pinball Bumper Obstacle
/// Applies outward explosive impulse force to colliding objects and flashes color for visual feedback.
/// </summary>
public class BumperObstacle : MonoBehaviour
{
    [Tooltip("Extra explosive impulse applied away from the bumper.")]
    [SerializeField] private float bounceMultiplier = 12f;

    [Tooltip("Flash color when struck.")]
    [SerializeField] private Color flashColor = Color.yellow;

    private Renderer rend;
    private Color originalColor;
    private Coroutine flashCoroutine;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalColor = rend.material.color;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRb = collision.rigidbody;
        if (otherRb != null)
        {
            // Calculate outward direction from bumper center to contact point
            Vector3 bounceDirection = (collision.contacts[0].point - transform.position).normalized;
            bounceDirection.y = Mathf.Max(0.2f, bounceDirection.y); // Ensure slight upward pop

            // Apply immediate impulse to the colliding ball
            otherRb.AddForce(bounceDirection * bounceMultiplier, ForceMode.Impulse);

            Debug.Log($"[Bumper Struck] {gameObject.name} popped {collision.gameObject.name} in direction {bounceDirection}");

            // Visual feedback: Flash color
            if (rend != null)
            {
                if (flashCoroutine != null) StopCoroutine(flashCoroutine);
                flashCoroutine = StartCoroutine(FlashColorRoutine());
            }
        }
    }

    private IEnumerator FlashColorRoutine()
    {
        rend.material.color = flashColor;
        yield return new WaitForSeconds(0.15f);
        rend.material.color = originalColor;
    }
}
