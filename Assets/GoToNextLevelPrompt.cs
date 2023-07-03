using UnityEngine;

public class GoToNextLevelPrompt : MonoBehaviour
{
    [SerializeField] GameObject promptCanvas;

    private void OnTriggerEnter(Collider other) {
        promptCanvas.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Stay(){
        promptCanvas.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Proceed()
    {
        promptCanvas.SetActive(false);
        Time.timeScale = 1;
        GetComponent<LevelManager>().Interact();
    }

    public void ProceedToLevelName(string name)
    {
        promptCanvas.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(GetComponent<LevelManager>().LoadLevelByNameAfterTime(name));
    }
}
