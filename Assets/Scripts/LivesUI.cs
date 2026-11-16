using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    public Image[] hearts;

    public Sprite redHeart;
    public Sprite grayHeart;

    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
                hearts[i].sprite = redHeart;
            else
                hearts[i].sprite = grayHeart;
        }
    }
}