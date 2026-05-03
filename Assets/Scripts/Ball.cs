using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    public void EnablePhysics() {
        rb.isKinematic = false;
        rb.useGravity = true;
    }

    public void DisablePhysics() {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    public void Throw(Vector3 forceDirection, float force) {
        rb.AddForce(forceDirection.normalized * force, ForceMode.Impulse);
    }
}
