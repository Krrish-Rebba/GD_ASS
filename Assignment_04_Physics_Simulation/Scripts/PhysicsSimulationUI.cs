using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Practical 4: UI Telemetry Display for Physics Simulation
/// Shows live speed, total bounces, and score on the screen.
/// </summary>
public class PhysicsSimulationUI : MonoBehaviour
{
    public static PhysicsSimulationUI Instance { get; private set; }

    [SerializeField] private BouncingBallPhysics ball;
    [SerializeField] private Text telemetryText;

    private int score = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    private void Update()
    {
        if (telemetryText != null && ball != null)
        {
            telemetryText.text = $"--- PHYSICS TELEMETRY ---\n" +
                                 $"Ball Speed: {ball.CurrentSpeed:F2} m/s\n" +
                                 $"Total Bounces: {ball.BounceCount}\n" +
                                 $"Score: {score}\n\n" +
                                 $"[Controls]\n" +
                                 $"Arrow Keys: Nudge Ball (AddForce)\n" +
                                 $"Spacebar: Upward Impulse\n" +
                                 $"R: Reset & Relaunch";
        }
    }
}
