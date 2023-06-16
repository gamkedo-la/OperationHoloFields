using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    public void RestartScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<PauseActivator>().TogglePause();

        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);
    }
}
