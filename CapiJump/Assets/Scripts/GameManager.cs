using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }

    [Header("UI")]
    [Tooltip("Painel (GameObject) com o texto 'Game Over' e o botão de restart")]
    public GameObject gameOverPanel;

    [Tooltip("Texto (opcional) dentro do painel pra mostrar quantas moedas foram coletadas")]
    public TextMeshProUGUI finalCoinsText;

    private void Awake()
    {
        // Singleton simples
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        IsGameOver = true;

        Debug.Log("Game Over!");

        if (gameOverPanel != null)
        
        {
            gameOverPanel.SetActive(true);
        }

        if (finalCoinsText != null && CoinManager.Instance != null)
        {
            finalCoinsText.text = "Moedas coletadas: " + CoinManager.Instance.coins;
        }

        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        IsGameOver = false;
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }
}