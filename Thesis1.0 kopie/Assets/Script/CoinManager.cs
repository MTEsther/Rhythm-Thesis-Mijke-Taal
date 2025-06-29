using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public int coinCount;
    public int totalCoins = 25;

    private bool doorDestroyed;
    public GameObject door;
    public TextMeshProUGUI coinText;

    void Start()
    {
        // Optional safety check: If coinText is still null, try to find it
        if (coinText == null)
        {
            coinText = GameObject.FindWithTag("CoinUI")?.GetComponent<TextMeshProUGUI>();
            if (coinText == null)
            {
                Debug.LogWarning("Coin Text UI not found or not assigned.");
            }
        }

        // Immediately update the UI
        UpdateCoinText();
    }

    void Update()
    {
        UpdateCoinText();

        if (coinCount == totalCoins && !doorDestroyed)
        {
            doorDestroyed = true;
            Destroy(door);
        }
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString() + " / " + totalCoins;
        }
    }
}
