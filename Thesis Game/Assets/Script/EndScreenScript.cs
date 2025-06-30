using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text coinsText;
    public TMP_Text correctText;
    public TMP_Text missedText;
    public TMP_Text livesText;

    public void Setup(int coins, float correctPercent, float missedPercent, int livesRemaining)
    {
        // Debug.Log("=== FINAL STATS ===");
        // Debug.Log("Total Coins: " + coins);
        // Debug.Log("Correct %: " + correctPercent);
        // Debug.Log("Missed %: " + missedPercent);
        // Debug.Log("Lives Left: " + livesRemaining);

        gameObject.SetActive(true); // VERY IMPORTANT
        coinsText.text = "COINS: " + coins.ToString();
        correctText.text = "ON BEAT: " + correctPercent.ToString("F1") + "%";
        missedText.text = "OFF BEAT: " + missedPercent.ToString("F1") + "%";
        livesText.text = "LIVES LEFT: " + livesRemaining.ToString();
    }


    public void ExitButton(){
        SceneManager.LoadScene("Level Selection");
    }

    
}
