using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void OpenControls()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(true);
    }

    public void CloseControls()
    {
        if (controlsPanel != null)
            controlsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Jogo encerrado.");
    }
}