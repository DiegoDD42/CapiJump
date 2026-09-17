using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool IsGameOver { get; private set; }

    [Header("UI - Game Over")]
    [Tooltip("Painel (GameObject) com o texto 'Game Over' e o botão de restart")]
    public GameObject gameOverPanel;

    [Tooltip("Texto (opcional) dentro do painel de game over pra mostrar quantas moedas foram coletadas")]
    public TextMeshProUGUI finalCoinsText;

    [Header("UI - Vitória")]
    [Tooltip("Painel (GameObject) com o texto de vitória e o botão de jogar novamente")]
    public GameObject winPanel;

    [Tooltip("Texto (opcional) dentro do painel de vitória pra mostrar quantas moedas foram coletadas")]
    public TextMeshProUGUI finalCoinsWinText;

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

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }
    }

    public void GameOver()
    {
        if (IsGameOver)
            return;

        Debug.Log("Game Over!");

        EndGame(gameOverPanel, finalCoinsText);
    }

    public void WinGame()
    {
        if (IsGameOver)
            return;

        Debug.Log("Vitória!");

        EndGame(winPanel, finalCoinsWinText);
    }

    private void EndGame(GameObject panelToShow, TextMeshProUGUI coinsTextField)
    {
        IsGameOver = true;

        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
        }

        if (coinsTextField != null && CoinManager.Instance != null)
        {
            coinsTextField.text = "Moedas coletadas: " + CoinManager.Instance.coins;
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

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;

        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}