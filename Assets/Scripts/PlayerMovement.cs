using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float acceleration = 20.0f;
    [SerializeField] private float rotationSpeed = 0.15f;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction lookAction;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        lookAction = playerInput.actions["Look"];
    }

    private void FixedUpdate() {
        if (!playerInput.enabled) return;
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement() {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0, input.y).normalized;
        Vector3 targetVelocity = direction * speed;
        targetVelocity.y = rb.linearVelocity.y;
        rb.linearVelocity = Vector3.Lerp(rb.linearVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
    }

    private void HandleRotation() {
        Vector2 lookDelta = lookAction.ReadValue<Vector2>();
        if (lookDelta.x != 0f) {
            float angle = lookDelta.x * rotationSpeed;
            rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, angle, 0f));
        }
    }
}
