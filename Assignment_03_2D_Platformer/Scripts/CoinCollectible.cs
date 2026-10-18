using UnityEngine;

/// <summary>
/// Practical 3: Collectible Coin / Gem
/// Uses 2D Trigger Collisions to award points to the player and destroy itself.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class CoinCollectible : MonoBehaviour
{
    [Tooltip("Points awarded when collected.")]
    [SerializeField] private int pointValue = 10;

    [Tooltip("Optional sound effect to play on pickup.")]
    [SerializeField] private AudioClip pickupAudio;

    private bool collected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Detect if the object entering this trigger has the "Player" tag
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;

            // Notify GameManager if it exists in the scene
            if (GameManager2D.Instance != null)
            {
                GameManager2D.Instance.AddScore(pointValue);
            }
            else
            {
                Debug.Log($"Collected item! Points +{pointValue}");
            }

            // Play pickup sound at the coin's position if an audio clip was assigned
            if (pickupAudio != null)
            {
                AudioSource.PlayClipAtPoint(pickupAudio, transform.position);
            }

            // Remove the coin from the game scene
            Destroy(gameObject);
        }
    }
}
