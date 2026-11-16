using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.PlayerWon(other.gameObject);
        }
    }
}