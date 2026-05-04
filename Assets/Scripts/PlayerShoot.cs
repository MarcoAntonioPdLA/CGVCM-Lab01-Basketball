using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour {
    public Ball ball;
    public GameObject shootPoint;
    [SerializeField] private float shootForce = 12f;

    private float forceStep = 0.25f;
    private float minForce = 8f;
    private float maxForce = 16f;
    private float upwardForce = 2f;
    private PlayerInput playerInput;
    private InputAction shootAction;
    private bool hasBall = true;

    private void Awake() {
        playerInput = GetComponent<PlayerInput>();
        shootAction = playerInput.actions["Shoot"];
    }

    void Update() {
        float scroll = Mouse.current.scroll.ReadValue().y;
        if (scroll != 0) {
            if (scroll > 0) {
                shootForce += forceStep;
            }
            else {
                shootForce -= forceStep;
            }
            shootForce = Mathf.Clamp(shootForce, minForce, maxForce);
            UIManager.Instance.UpdateForce(shootForce);
        }
        if (shootAction.WasPressedThisFrame() && hasBall) {
            Shoot();
        }
    }

    private void Shoot() {
        hasBall = false;
        ball.transform.parent = null;
        ball.EnablePhysics();

        Vector3 forceDirection = transform.forward + Vector3.up * upwardForce;
        ball.Throw(forceDirection, shootForce);
    }

    public void SetHasBall(bool hasBall) {
        this.hasBall = hasBall;
    }
}
