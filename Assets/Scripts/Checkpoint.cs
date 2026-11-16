using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.currentRespawnPoint = transform;
                Debug.Log("Checkpoint ativado!");
            }
        }
    }
}