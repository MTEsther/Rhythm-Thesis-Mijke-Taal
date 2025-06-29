using UnityEngine;

public static class StatsTracker
{
    // Coins collected across all levels in a session
    public static int totalCoins = 0;

    // Total number of correct movements (on beat)
    public static int correctMoves = 0;

    // Total number of attempted movements (on + off beat)
    public static int totalMoves = 0;

    // Lives remaining at any given point (should match HealthManager.health)
    public static int livesRemaining = 3;

    // Resets all statistics (call this when a new session starts)
    public static void Reset()
    {
        totalCoins = 0;
        correctMoves = 0;
        totalMoves = 0;
        livesRemaining = 3;
    }
}
