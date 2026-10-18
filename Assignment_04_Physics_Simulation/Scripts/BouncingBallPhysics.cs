using UnityEngine;

/// <summary>
/// Practical 4: Physics Motion & Force Controller
/// Demonstrates Rigidbody force/impulse application and collision response.
/// Works in 2D or 3D (3D Rigidbody version).
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class BouncingBallPhysics : MonoBehaviour
{
    [Header("Impulse & Launch Settings")]
    [Tooltip("Initial launch force applied when spacebar is pressed.")]
    [SerializeField] private float launchForce = 15f;

    [Tooltip("Continuous directional nudge force when arrow keys are pressed.")]
    [SerializeField] private float nudgeForce = 10f;

    [Header("Audio & Feedback")]
    [Tooltip("Audio clip played whenever the ball strikes a surface.")]
    [SerializeField] private AudioClip bounceSound;

    private Rigidbody rb;
    private int bounceCount = 0;

    public int BounceCount => bounceCount;
    public float CurrentSpeed => rb != null ? rb.linearVelocity.magnitude : 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Launch ball initially with random angle to kick off simulation
        LaunchRandom();
    }

    private void Update()
    {
        // Spacebar applies an immediate vertical impulse force
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyImpulse(Vector3.up * launchForce);
        }

        // R key resets the ball position and relaunches
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetBall();
        }
    }

    private void FixedUpdate()
    {
        // Directional nudging using ForceMode.Force (continuous acceleration)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (Mathf.Abs(moveX) > 0.05f || Mathf.Abs(moveZ) > 0.05f)
        {
            Vector3 nudge = new Vector3(moveX, 0f, moveZ) * nudgeForce;
            rb.AddForce(nudge, ForceMode.Force);
        }
    }

    public void ApplyImpulse(Vector3 forceVector)
    {
        // AddForce with ForceMode.Impulse applies an instant momentum change (ideal for hits/bounces)
        rb.AddForce(forceVector, ForceMode.Impulse);
        Debug.Log($"[Physics Practical 4] Applied Impulse: {forceVector}. Current Velocity: {rb.linearVelocity}");
    }

    public void ResetBall()
    {
        transform.position = new Vector3(0f, 5f, 0f);
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        bounceCount = 0;
        LaunchRandom();
    }

    private void LaunchRandom()
    {
        Vector3 randomDir = new Vector3(Random.Range(-0.8f, 0.8f), 0.5f, Random.Range(-0.8f, 0.8f)).normalized;
        ApplyImpulse(randomDir * launchForce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounceCount++;
        float impactSpeed = collision.relativeVelocity.magnitude;

        Debug.Log($"[Collision Detected] Collided with '{collision.gameObject.name}'. Relative Speed: {impactSpeed:F2} m/s. Total Bounces: {bounceCount}");

        // Play audio if assigned
        if (bounceSound != null)
        {
            AudioSource.PlayClipAtPoint(bounceSound, transform.position, Mathf.Clamp01(impactSpeed / 10f));
        }
    }
}
