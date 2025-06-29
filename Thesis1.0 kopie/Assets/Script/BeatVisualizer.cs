using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BeatVisualizer : MonoBehaviour
{
    [SerializeField] private float bpm = 120f;
    [SerializeField] private Image pulseImage;
    [SerializeField] private Color pulseColor = Color.red;
    [SerializeField] private AudioClip beatClickSound;   // NEW
    private AudioSource audioSource;                    // NEW

    private float beatInterval;
    private float nextBeatTime;
    private Vector3 originalScale;

    private void Start()
    {
        beatInterval = 60f / bpm;
        nextBeatTime = Time.time + beatInterval;
        originalScale = pulseImage.transform.localScale;

        audioSource = gameObject.AddComponent<AudioSource>();  // NEW
        audioSource.playOnAwake = false;
    }

    private void Update()
    {
        if (Time.time >= nextBeatTime)
        {
            nextBeatTime += beatInterval;
            StartCoroutine(Pulse());

            // 🔊 Play beat click sound
            if (beatClickSound != null)
            {
                audioSource.PlayOneShot(beatClickSound);
            }
        }
    }

    private IEnumerator Pulse()
    {
        float pulseDuration = 0.2f;
        float t = 0;
        pulseImage.color = pulseColor;

        while (t < pulseDuration)
        {
            t += Time.deltaTime;
            float scale = 1 + Mathf.Sin(t / pulseDuration * Mathf.PI) * 0.3f;
            pulseImage.transform.localScale = originalScale * scale;
            yield return null;
        }

        pulseImage.transform.localScale = originalScale;
        pulseImage.color = Color.white;
    }
}
