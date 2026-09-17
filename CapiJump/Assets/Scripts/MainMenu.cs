using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "GameScene";

    public void PlayGame()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        Debug.Log("Saindo do jogo...");

        Application.Quit();
    }
}