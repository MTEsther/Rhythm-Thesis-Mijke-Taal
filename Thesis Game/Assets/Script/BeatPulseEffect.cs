using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeatPulseEffect : MonoBehaviour
{
    public Transform trackedTarget;
    public Camera mainCamera;
    public float pulseScale = 1.3f;
    public float pulseSpeed = 0.25f;

    public Color defaultColor = Color.white;
    public Color successColor = Color.green;
    public Color failColor = Color.red;

    private SpriteRenderer spriteRenderer;
    private float beatInterval = 0.5f; // 120 BPM = 0.5s
    private float lastBeatTime;

    public bool isSyncopated = false; // default = false
    private int pulseCount = 0;

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ResetBeat(float syncTime)
    {
        lastBeatTime = syncTime;

        // Apply syncopation shift if needed
        if (isSyncopated)
        {
            lastBeatTime += beatInterval / 2f;
            Debug.Log("Initial syncopation offset applied");
        }
    }

    private void Start()
    {
        spriteRenderer.color = defaultColor;

        // Automatically enable syncopation for specific levels
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level 2" || sceneName == "Level 5")
        {
            isSyncopated = true;
            Debug.Log("Syncopation enabled for " + sceneName);
        }

        lastBeatTime = Time.time;
        if (isSyncopated)
        {
            lastBeatTime += beatInterval / 2f; // initial shift for off-beat
        }
    }

    private void Update()
    {
        if (trackedTarget != null)
        {
            transform.position = trackedTarget.position;
        }

        if (Time.time >= lastBeatTime + beatInterval)
        {
            lastBeatTime += beatInterval;
            Debug.Log($"[{pulseCount}] Pulse triggered ({(isSyncopated ? "Off-beat" : "On-beat")}) at {Time.time:F3}s");
            StartCoroutine(Pulse(true));
            pulseCount++;
        }
    }

    private IEnumerator Pulse(bool startAtPeak = false)
    {
        Vector3 originalScale = transform.localScale;
        Vector3 peakScale = originalScale * pulseScale;

        if (startAtPeak)
        {
            transform.localScale = peakScale;
            float elapsed = 0f;
            while (elapsed < pulseSpeed)
            {
                transform.localScale = Vector3.Lerp(peakScale, originalScale, elapsed / pulseSpeed);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.localScale = originalScale;
        }
        else
        {
            float elapsed = 0f;
            while (elapsed < pulseSpeed)
            {
                transform.localScale = Vector3.Lerp(originalScale, peakScale, elapsed / pulseSpeed);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = peakScale;

            elapsed = 0f;
            while (elapsed < pulseSpeed)
            {
                transform.localScale = Vector3.Lerp(peakScale, originalScale, elapsed / pulseSpeed);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.localScale = originalScale;
        }
    }

    public void SetLastInputResult(bool success)
    {
        if (spriteRenderer == null) return;

        Color flashColor = success ? successColor : failColor;
        StopCoroutine("Flash");
        StartCoroutine(Flash(flashColor));
    }

    private IEnumerator Flash(Color flashColor)
    {
        spriteRenderer.color = flashColor;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = defaultColor;
    }
}


