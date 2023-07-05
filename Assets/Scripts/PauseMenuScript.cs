using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject pauseButtonsPannel;
    [SerializeField] GameObject commandsPannel;

    public void DisplayPauseButtons()
    {
        commandsPannel.SetActive(false);
        pauseButtonsPannel.SetActive(true);
    }

    public void DisplayCommandsPannel()
    {
        commandsPannel.SetActive(true);
        pauseButtonsPannel.SetActive(false);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
