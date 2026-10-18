using UnityEngine;

/// <summary>
/// Practical 7: XR Object Interaction
/// Enables touch/click interaction: cycling materials, 360-degree rotation, and scaling.
/// </summary>
public class XRInteractiveObject : MonoBehaviour
{
    [Header("Interactive Feedback")]
    [SerializeField] private Color[] colorPalette = new Color[] { Color.cyan, Color.magenta, Color.yellow, Color.white };
    [SerializeField] private float rotationSpeed = 50f;

    private Renderer rend;
    private int currentColorIndex = 0;
    private Vector3 lastMousePosition;
    private bool isDragging = false;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        // Continuous subtle idle rotation to make it feel alive in AR
        transform.Rotate(Vector3.up * (rotationSpeed * 0.2f * Time.deltaTime));

        // Drag to rotate manually
        if (Input.GetMouseButtonDown(1))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = Input.mousePosition - lastMousePosition;
            transform.Rotate(Vector3.up, -delta.x * rotationSpeed * Time.deltaTime, Space.World);
            lastMousePosition = Input.mousePosition;
        }

        // Mouse scroll to scale up or down
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
        {
            float newScale = Mathf.Clamp(transform.localScale.x + scroll, 0.2f, 3.0f);
            transform.localScale = Vector3.one * newScale;
        }
    }

    private void OnMouseDown()
    {
        // Click or tap directly on the object to cycle its color
        CycleColor();
    }

    public void CycleColor()
    {
        if (rend != null && colorPalette.Length > 0)
        {
            currentColorIndex = (currentColorIndex + 1) % colorPalette.Length;
            rend.material.color = colorPalette[currentColorIndex];
            Debug.Log($"[XR Interaction] Color changed to: {colorPalette[currentColorIndex]}");
        }
    }
}
