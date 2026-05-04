using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI forceText;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private Button restartButton;

    private GameManager gameManager;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Para llamar a la función OnSceneLoaded en lugar de Start
    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        winPanel.SetActive(false);
        UpdateScore(0);
        UpdateForce(12);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartScene);
    }

    public void UpdateScore(int points) {
        scoreText.text = $"Puntos: {points}";
        if (points >= GameManager.MAX_POINTS) {
            gameManager.DisablePlayerInput();
            ShowWinPanel();
        }
    }

    public void UpdateForce(float force) {
        forceText.text = $"Fuerza de lanzamiento: {force}";
    }

    private void ShowWinPanel() {
        winPanel.SetActive(true);
    }

    private void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
