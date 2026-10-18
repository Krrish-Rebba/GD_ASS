using UnityEngine;

/// <summary>
/// Practical 5: Visual AI State Indicator
/// Dynamically updates the AI agent's material color to reflect its active state.
/// </summary>
public class AIStateIndicator : MonoBehaviour
{
    [SerializeField] private EnemyAIController aiController;
    [SerializeField] private Renderer targetRenderer;

    [Header("State Colors")]
    [SerializeField] private Color patrolColor = Color.green;
    [SerializeField] private Color chaseColor = Color.yellow;
    [SerializeField] private Color attackColor = Color.red;

    private Material dynamicMaterial;

    private void Start()
    {
        if (targetRenderer == null) targetRenderer = GetComponent<Renderer>();
        if (aiController == null) aiController = GetComponent<EnemyAIController>();

        if (targetRenderer != null)
        {
            dynamicMaterial = targetRenderer.material;
        }
    }

    private void Update()
    {
        if (aiController == null || dynamicMaterial == null) return;

        switch (aiController.CurrentState)
        {
            case EnemyAIController.AIState.Patrol:
                dynamicMaterial.color = patrolColor;
                break;
            case EnemyAIController.AIState.Chase:
                dynamicMaterial.color = chaseColor;
                break;
            case EnemyAIController.AIState.StopInRange:
                dynamicMaterial.color = attackColor;
                break;
        }
    }
}
