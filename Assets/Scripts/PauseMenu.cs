using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject settingsPanel;
    public GameObject controlsPanel;

    public void OpenMenu()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        settingsPanel.SetActive(false);

        if (controlsPanel != null)
            controlsPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void OpenControls()
    {
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        controlsPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}