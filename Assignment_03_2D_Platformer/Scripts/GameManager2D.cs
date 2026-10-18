using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Practical 3: Game Manager & UI Controller
/// Tracks score, player lives, updates UI, and manages respawning.
/// </summary>
public class GameManager2D : MonoBehaviour
{
    public static GameManager2D Instance { get; private set; }

    [Header("Gameplay Variables")]
    [SerializeField] private int currentScore = 0;
    [SerializeField] private int playerLives = 3;

    [Header("UI References (Optional)")]
    [Tooltip("UI Text element to display current score.")]
    [SerializeField] private Text scoreText;

    [Tooltip("UI Text element to display remaining lives.")]
    [SerializeField] private Text livesText;

    private void Awake()
    {
        // Singleton pattern to allow easy access from any script
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    public void LoseLife()
    {
        playerLives--;
        UpdateUI();

        if (playerLives <= 0)
        {
            Debug.Log("Game Over! Restarting scene...");
            RestartScene();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }
        if (livesText != null)
        {
            livesText.text = $"Lives: {playerLives}";
        }
    }
}
