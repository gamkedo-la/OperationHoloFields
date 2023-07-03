using UnityEngine;
using UnityEngine.SceneManagement;

public class HellRespawn : MonoBehaviour
{
    [SerializeField] GameObject retryPrompter;

    private void OnTriggerExit(Collider other) 
    {
        if (!other.CompareTag("Player")) return;

        retryPrompter.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Retry()
    {
        retryPrompter.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Quit()
    {
        retryPrompter.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("TheCorridor");
    }
}
