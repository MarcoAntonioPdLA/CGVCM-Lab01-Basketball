using UnityEngine;

public class Ball : MonoBehaviour {
    public Transform player;
    public Transform shootingPoint;

    private const float TIME_TO_RETURN = 2f;

    private Rigidbody rb;
    private bool isReturning = false;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Floor") && !isReturning) {
            isReturning = true;
            Invoke(nameof(ReturnToPlayer), TIME_TO_RETURN);
        }
    }

    private void OnTriggerEnter(Collider collider) {
        if(collider.CompareTag("Ring")) {
            Debug.Log("Canasta");
        }
    }

    private void ReturnToPlayer() {
        rb.linearVelocity = Vector3.zero;
        DisablePhysics();
        transform.SetParent(player);
        transform.position = shootingPoint.position;
        player.GetComponent<PlayerShoot>().SetHasBall(true);
        isReturning = false;
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
