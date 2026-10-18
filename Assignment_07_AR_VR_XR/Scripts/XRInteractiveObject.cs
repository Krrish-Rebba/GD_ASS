using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Practical 7: XR Object Interaction
/// Enables touch/click interaction: cycling materials, 360-degree rotation, and scaling.
/// Supports both New Input System and Legacy Input.
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

        // Right-click drag to rotate manually
        bool rightDown = false;
        bool rightUp = false;
        Vector3 currentMousePos = Vector3.zero;
        float scrollDelta = 0f;

#if ENABLE_INPUT_SYSTEM
        if (Mouse.current != null)
        {
            rightDown = Mouse.current.rightButton.wasPressedThisFrame;
            rightUp = Mouse.current.rightButton.wasReleasedThisFrame;
            currentMousePos = Mouse.current.position.ReadValue();
            scrollDelta = Mouse.current.scroll.ReadValue().y * 0.002f;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                // Raycast check to cycle color on click in New Input System
                Ray ray = Camera.main.ScreenPointToRay(currentMousePos);
                if (Physics.Raycast(ray, out RaycastHit hit) && hit.transform == transform)
                {
                    CycleColor();
                }
            }
        }
        else
#endif
        {
            rightDown = Input.GetMouseButtonDown(1);
            rightUp = Input.GetMouseButtonUp(1);
            currentMousePos = Input.mousePosition;
            scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        }

        if (rightDown)
        {
            isDragging = true;
            lastMousePosition = currentMousePos;
        }
        else if (rightUp)
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 delta = currentMousePos - lastMousePosition;
            transform.Rotate(Vector3.up, -delta.x * rotationSpeed * Time.deltaTime, Space.World);
            lastMousePosition = currentMousePos;
        }

        // Mouse scroll to scale up or down
        if (Mathf.Abs(scrollDelta) > 0.001f)
        {
            float newScale = Mathf.Clamp(transform.localScale.x + scrollDelta, 0.2f, 3.0f);
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
