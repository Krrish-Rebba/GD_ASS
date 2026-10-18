using UnityEngine;

/// <summary>
/// Practical 5: Simple 3D Player Controller
/// Allows keyboard movement so you can run around obstacles while the NavMesh AI pursues you.
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

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
