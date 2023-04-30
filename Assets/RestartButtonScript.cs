using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButtonScript : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    PlayerMovement playerMovementScript;

    private void Start()
    {
        playerMovementScript = playerObject.transform.GetComponent<PlayerMovement>();
    }
    public void RestartScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerMovementScript.TogglePause();

        Scene currentScene = SceneManager.GetActiveScene();
        string currentSceneName = currentScene.name;
        SceneManager.LoadScene(currentSceneName);
    }
}
