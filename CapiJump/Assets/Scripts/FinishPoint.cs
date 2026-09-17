using UnityEngine;

public class FinishPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.Instance != null)
            GameManager.Instance.WinGame();
    }

}