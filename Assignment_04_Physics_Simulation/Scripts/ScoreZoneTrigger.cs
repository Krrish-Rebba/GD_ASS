using UnityEngine;

/// <summary>
/// Practical 4: Trigger-Based High-Score Zone
/// Demonstrates OnTriggerEnter vs OnCollisionEnter.
/// </summary>
public class ScoreZoneTrigger : MonoBehaviour
{
    [SerializeField] private int pointsAwarded = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.GetComponent<BouncingBallPhysics>() != null)
        {
            Debug.Log($"[Trigger Zone Activated] Object {other.name} entered {gameObject.name}. Awarded +{pointsAwarded} points!");
            
            if (PhysicsSimulationUI.Instance != null)
            {
                PhysicsSimulationUI.Instance.AddScore(pointsAwarded);
            }
        }
    }
}
