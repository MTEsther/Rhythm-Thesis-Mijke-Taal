using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;

    public void OpenScene()
    {
        Time.timeScale = 1f; // ✅ Unpause the game
        StatsTracker.Reset();

        // Reset the timer only for levels 1, 2, or 3
        if (level == 1 || level == 2 || level == 3)
        {
            GameTimer.ResetGlobalTimer();
        }

        SceneManager.LoadScene("Level " + level.ToString());
    }
}
