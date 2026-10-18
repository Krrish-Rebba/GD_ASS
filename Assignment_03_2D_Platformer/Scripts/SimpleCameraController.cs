using UnityEngine;

/// <summary>
/// Practical 3: Smooth 2D Camera Follow
/// Follows the player character smoothly along X and Y axes with customizable offset.
/// </summary>
public class SimpleCameraController : MonoBehaviour
{
    [Tooltip("The player transform that the camera will follow.")]
    [SerializeField] private Transform target;

    [Tooltip("Smoothing factor (higher = smoother lag, lower = snappier).")]
    [SerializeField] private float smoothTime = 0.25f;

    [Tooltip("Offset distance relative to the target.")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 1f, -10f);

    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        // LateUpdate runs after all Update functions have finished, avoiding camera jitter
        if (target == null) return;

        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
