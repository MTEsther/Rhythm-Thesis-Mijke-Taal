using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text coinsText;
    public TMP_Text correctText;
    public TMP_Text missedText; 

    public void Setup(int coins, float correctPercent, float missedPercent)
    {
        gameObject.SetActive(true);
        coinsText.text = "COINS: " + coins.ToString();
        correctText.text = "ON BEAT: " + correctPercent.ToString("F1") + "%";
        missedText.text = "OFF BEAT: " + missedPercent.ToString("F1") + "%";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 

    public void ExitButton(){
        SceneManager.LoadScene("Level Selection");
    }


}

