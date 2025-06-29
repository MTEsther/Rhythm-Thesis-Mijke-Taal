using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransitionHelper : MonoBehaviour
{
    public void StartDelayedTransition(string sceneName, float delay)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
