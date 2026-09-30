using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName = "GameScene";

    public void PlayGame()
    {
        AudioManager.Instance?.PlaySFX(SfxId.UIClick);
        Time.timeScale = 1f;

        SceneManager.LoadScene(gameSceneName);
    }

    public void ExitGame()
    {
        AudioManager.Instance?.PlaySFX(SfxId.UIClick);
        Debug.Log("Saindo do jogo...");

        Application.Quit();
    }
}