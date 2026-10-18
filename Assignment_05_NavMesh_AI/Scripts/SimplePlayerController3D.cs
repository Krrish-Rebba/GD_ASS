using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

/// <summary>
/// Practical 5: Simple 3D Player Controller
/// Allows keyboard movement so you can run around obstacles while the NavMesh AI pursues you.
/// Supports both New Input System and Legacy Input.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class SimplePlayerController3D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float gravity = 20f;

    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        // Automatically ensure Player tag is set
        gameObject.tag = "Player";
    }

    private void Update()
    {
        float horizontal = 0f;
        float vertical = 0f;

#if ENABLE_INPUT_SYSTEM
        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) horizontal -= 1f;
            if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) horizontal += 1f;
            if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) vertical += 1f;
            if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) vertical -= 1f;
        }
        else
#endif
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }

        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (controller.isGrounded)
        {
            moveDirection = inputDir * moveSpeed;
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        controller.Move(moveDirection * Time.deltaTime);

        // Rotate in the direction of movement
        if (inputDir.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
    }
}
