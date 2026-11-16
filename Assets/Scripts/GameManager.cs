using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Vidas")]
    public int maxLives = 5;
    public int currentLives;

    [Header("Respawn")]
    public Transform firstRespawnPoint;
    public Transform currentRespawnPoint;

    [Header("UI")]
    public LivesUI livesUI;
    public GameObject gameOverPanel;
    public GameObject winPanel;

    private GameObject currentPlayer;

    private void Start()
    {
        currentLives = maxLives;
        currentRespawnPoint = firstRespawnPoint;

        UpdateLivesUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (winPanel != null)
            winPanel.SetActive(false);
    }

    public void PlayerDied(GameObject player)
    {
        currentPlayer = player;

        currentLives--;

        UpdateLivesUI();

        if (currentLives > 0)
        {
            StartCoroutine(RespawnPlayer(player));
        }
        else
        {
            GameOver();
        }
    }

    private IEnumerator RespawnPlayer(GameObject player)
    {
        if (player == null)
            yield break;

        Transform respawnPoint = currentRespawnPoint;

        if (respawnPoint == null)
            respawnPoint = firstRespawnPoint;

        if (respawnPoint == null)
            yield break;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.simulated = false;

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;

            player.transform.position = respawnPoint.position;

            Physics2D.SyncTransforms();

            yield return new WaitForFixedUpdate();

            rb.simulated = true;
            rb.linearVelocity = Vector2.zero;
            rb.WakeUp();
        }
        else
        {
            player.transform.position = respawnPoint.position;
        }
    }

    private void GameOver()
    {
        if (currentPlayer != null)
        {
            Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
            PlayerMovement movement = currentPlayer.GetComponent<PlayerMovement>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }

            if (movement != null)
            {
                movement.enabled = false;
            }

            currentPlayer.SetActive(false);
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void RetryGame()
    {
        currentLives = maxLives;
        currentRespawnPoint = firstRespawnPoint;

        UpdateLivesUI();

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        ResetPlayerToStart();
    }

    public void PlayerWon(GameObject player)
    {
        currentPlayer = player;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        PlayerMovement movement = player.GetComponent<PlayerMovement>();

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false;
        }

        if (movement != null)
        {
            movement.enabled = false;
        }

        player.SetActive(false);

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        currentLives = maxLives;
        currentRespawnPoint = firstRespawnPoint;

        UpdateLivesUI();

        if (winPanel != null)
        {
            winPanel.SetActive(false);
        }

        ResetPlayerToStart();
    }

    private void ResetPlayerToStart()
    {
        if (currentPlayer == null)
            return;

        currentPlayer.SetActive(true);

        if (firstRespawnPoint != null)
        {
            currentPlayer.transform.position = firstRespawnPoint.position;
        }

        Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
        PlayerMovement movement = currentPlayer.GetComponent<PlayerMovement>();

        if (rb != null)
        {
            rb.simulated = true;
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.WakeUp();
        }

        if (movement != null)
        {
            movement.enabled = true;
        }

        Physics2D.SyncTransforms();
    }

    private void UpdateLivesUI()
    {
        if (livesUI != null)
        {
            livesUI.UpdateLives(currentLives);
        }
    }
}