using UnityEngine;

public class GameManager : MonoBehaviour {
    public Transform shootingArea;
    public Transform player;

    private const float SHOOTING_AREA_Y_DEFAULT = 1f;
    private const float PLAYER_Y_DEFAULT = 2f;

    private void Awake() {

    }

    public void SetNewShootingArea() {
        float newX = Random.Range(-6.5f, 6.5f);
        float newZ = Random.Range(-6.5f, 2.5f);
        shootingArea.position = new Vector3(newX, SHOOTING_AREA_Y_DEFAULT, newZ);
        player.position = new Vector3(newX, PLAYER_Y_DEFAULT, newZ);
    }
}
