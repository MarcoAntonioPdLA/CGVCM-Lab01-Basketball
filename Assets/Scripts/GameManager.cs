using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    private const float SHOOTING_AREA_Y_DEFAULT = 1f;
    private const float PLAYER_Y_DEFAULT = 2f;

    public Transform shootingArea;
    public Transform player;
    public PlayerInput playerInput;

    public const int MAX_POINTS = 1;
    public int points = 0;

    private void Update() {
        if (Keyboard.current.escapeKey.wasPressedThisFrame) {
            Application.Quit();
        }
    }

    public void SetNewShootingArea() {
        float newX = Random.Range(-6.5f, 6.5f);
        float newZ = Random.Range(-6.5f, 2.5f);
        shootingArea.position = new Vector3(newX, SHOOTING_AREA_Y_DEFAULT, newZ);
        player.position = new Vector3(newX, PLAYER_Y_DEFAULT, newZ);
    }

    public void AddPoint() {
        points++;
        UIManager.Instance.UpdateScore(points);
    }

    public void DisablePlayerInput() {
        Debug.Log("X - deshabilitando input de: " + playerInput.gameObject.name);
        playerInput.enabled = false;
    }
}
