using UnityEngine;
using UnityEngine.InputSystem;

public class PauseActivator : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool gameIsPaused = false;
    public void OnTogglePause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        TogglePause();
    }

    public void TogglePause()
    {
        if (!gameIsPaused)
        {
            pauseMenu.SetActive(true);
            pauseMenu.GetComponent<PauseMenuScript>().DisplayPauseButtons();
            Time.timeScale = 0;
            gameIsPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (gameIsPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            gameIsPaused = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
