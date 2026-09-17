using TMPro;
using UnityEngine;

public class CoinUI : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Start()
    {
        UpdateCoinText();
    }

    private void Update()
    {
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Moedas: " + CoinManager.Instance.coins;
    }
}