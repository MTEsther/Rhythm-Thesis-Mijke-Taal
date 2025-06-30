using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public float maxTime = 180f; // 3 minutes
    public GameObject endScreen; // Assign in Inspector

    // Static fields to persist across scenes
    private static float globalTimer = 0f;
    private static bool gameEnded = false;

    public static void ResetGlobalTimer()
    {
        globalTimer = 0f;
        gameEnded = false;
    }

    void Update()
    {
        if (gameEnded) return;

        globalTimer += Time.unscaledDeltaTime;

        if (globalTimer >= maxTime)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;

        // Disable player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.SetActive(false);
        }

        // Show stats
        if (endScreen != null)
        {
            float correctPercent = StatsTracker.totalMoves > 0
                ? (StatsTracker.correctMoves / (float)StatsTracker.totalMoves) * 100f
                : 0f;

            float missedPercent = 100f - correctPercent;

            EndScreen end = endScreen.GetComponent<EndScreen>();
            if (end != null)
            {
                end.Setup(
                    StatsTracker.totalCoins,
                    correctPercent,
                    missedPercent,
                    StatsTracker.livesRemaining
                );
            }

            endScreen.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
