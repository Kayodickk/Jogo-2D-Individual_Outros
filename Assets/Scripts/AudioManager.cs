using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("Botão de Som")]
    public Image soundButtonImage;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    private bool isMuted;

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;

        ApplySound();
        UpdateIcon();
    }

    public void ToggleSound()
    {
        isMuted = !isMuted;

        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        PlayerPrefs.Save();

        ApplySound();
        UpdateIcon();
    }

    private void ApplySound()
    {
        AudioListener.volume = isMuted ? 0f : 1f;
    }

    private void UpdateIcon()
    {
        if (soundButtonImage != null)
        {
            soundButtonImage.sprite = isMuted
                ? soundOffSprite
                : soundOnSprite;
        }
    }
}