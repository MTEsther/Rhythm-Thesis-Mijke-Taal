using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 5f;

    [Header("Beat Settings")]
    [SerializeField] private float bpm = 120f;
    [SerializeField] private float beatWindow = 0.15f;

    [Header("Input Timing Settings")]
    [SerializeField, Range(0.1f, 1f)]
    private float inputCooldownFraction = 0.5f;

    [Tooltip("Assign the layer that contains solid objects like walls.")]
    [SerializeField] private LayerMask _solidObjectsLayer;

    [Header("Enemy Collision Settings")]
    [SerializeField] private float immunityDuration = 2f;
    [SerializeField] private float blinkInterval = 0.2f;

    private bool _isMoving = false;
    private bool _isImmune = false;
    private bool inputHeld = false;

    private Vector2 _input;
    private Animator _animator;
    private Rigidbody2D _rb;
    private BeatPulseEffect _pulseEffect;
    private SpriteRenderer _spriteRenderer;

    private float beatInterval;
    private float inputCooldown;
    private float startTime;
    private float _nextMoveAllowedTime = 0f;

    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";

    public CoinManager cm;
    public GameOverScreen GameOverScreen;
    public GameObject endScreen;

    private int totalMovementAttempts = 0;
    private int correctMovements = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _pulseEffect = GetComponentInChildren<BeatPulseEffect>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawn");
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
        else
        {
            Debug.LogWarning("PlayerSpawn not found, using fallback position.");
            transform.position = new Vector3(-1.5f, 2.5f, 0f);
        }

        beatInterval = 60f / bpm;
        inputCooldown = beatInterval * inputCooldownFraction;

        startTime = Time.time;
        if (_pulseEffect != null)
        {
            _pulseEffect.ResetBeat(startTime);
        }
    }

   private void Update()
    {
        if (_isMoving || Time.time < _nextMoveAllowedTime) return;

        // Reset key state if no input is being held
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            inputHeld = false;
        }

        // Prevent movement if key is still held down
        if (inputHeld) return;

        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        if (_input.x != 0 || _input.y != 0)
        {
            inputHeld = true; // Block further input until released

            if (_input.x != 0) _input.y = 0;

            totalMovementAttempts++;
            StatsTracker.totalMoves++;

            _animator.SetFloat(_horizontal, _input.x);
            _animator.SetFloat(_vertical, _input.y);
            _animator.SetFloat(_lastHorizontal, _input.x);
            _animator.SetFloat(_lastVertical, _input.y);

            Vector2 targetPos = (Vector2)transform.position + _input;

            if (IsOnBeat())
            {
                Debug.Log("✔ On Beat");

                if (IsWalkable(targetPos))
                {
                    correctMovements++;
                    StatsTracker.correctMoves++;
                    StartCoroutine(MovePlayer(targetPos));
                    _pulseEffect?.SetLastInputResult(true);
                }
            }
            else
            {
                Debug.Log("✘ Off Beat");
                _pulseEffect?.SetLastInputResult(false);
            }

            _nextMoveAllowedTime = Time.time + inputCooldown;
        }
    }

    private IEnumerator MovePlayer(Vector2 targetPos)
    {
        _isMoving = true;
        Vector2 startPosition = _rb.position;
        float elapsedTime = 0f;

        while (elapsedTime < 1f / _moveSpeed)
        {
            Vector2 newPos = Vector2.Lerp(startPosition, targetPos, elapsedTime * _moveSpeed);
            _rb.MovePosition(newPos);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _rb.MovePosition(targetPos);
        _isMoving = false;
    }

    private bool IsWalkable(Vector2 targetPos)
    {
        Collider2D hit = Physics2D.OverlapCircle(targetPos, 0.2f, _solidObjectsLayer);
        return hit == null;
    }

    private bool IsOnBeat()
    {
        float timeSinceStart = Time.time - startTime;
        float timeToNextBeat = beatInterval - (timeSinceStart % beatInterval);
        float distanceToPeak = Mathf.Abs(timeToNextBeat - (beatInterval / 2f));

        Debug.Log("Time to pulse peak: " + distanceToPeak.ToString("F3"));

        return distanceToPeak <= beatWindow;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isImmune)
        {
            HealthManager.health--;
            StatsTracker.livesRemaining = HealthManager.health;

            HealthManager hm = Object.FindFirstObjectByType<HealthManager>();
            if (hm != null)
            {
                hm.UpdateHearts();
            }

            if (HealthManager.health <= 0)
            {
                GameOver();
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(StartImmunity());
            }
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            cm.coinCount++;
            StatsTracker.totalCoins++;
        }

        if (collision.gameObject.CompareTag("EndPoint"))
        {
            float correctPercentage = StatsTracker.totalMoves > 0
                ? (StatsTracker.correctMoves / (float)StatsTracker.totalMoves) * 100f
                : 0f;

            float missedPercentage = 100f - correctPercentage;

            EndScreen endScreenScript = endScreen.GetComponent<EndScreen>();
            if (endScreenScript != null)
            {
                Debug.Log("Calling EndScreen.Setup...");
                endScreenScript.Setup(
                    StatsTracker.totalCoins,
                    correctPercentage,
                    missedPercentage,
                    StatsTracker.livesRemaining
                );
            }

            string nextScene = "";
            string currentScene = SceneManager.GetActiveScene().name;

            switch (currentScene)
            {
                case "Level 1": nextScene = "Level 4"; break;
                case "Level 2": nextScene = "Level 5"; break;
                case "Level 3": nextScene = "Level 6"; break;
                default: return;
            }

            // Call the coroutine from a still-active object
            GameObject.FindObjectOfType<LevelTransitionHelper>().StartDelayedTransition(nextScene, 3f);

            // THEN deactivate player
            gameObject.SetActive(false);
        }

    }

    private IEnumerator StartImmunity()
    {
        _isImmune = true;

        float elapsed = 0f;
        while (elapsed < immunityDuration)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
            yield return new WaitForSeconds(blinkInterval);
            elapsed += blinkInterval;
        }

        _spriteRenderer.enabled = true;
        _isImmune = false;
    }

    public void GameOver()
    {
        if (GameOverScreen != null && cm != null)
        {
            float correctPercentage = totalMovementAttempts > 0
                ? (correctMovements / (float)totalMovementAttempts) * 100f
                : 0f;

            float missedPercentage = 100f - correctPercentage;

            GameOverScreen.Setup(cm.coinCount, correctPercentage, missedPercentage);
        }

        // Reload the current level after a short delay
        StartCoroutine(ReloadLevelAfterDelay(2f));
    }

    private IEnumerator ReloadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Reset time scale in case it was paused elsewhere
        Time.timeScale = 1f;

        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

