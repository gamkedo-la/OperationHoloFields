using UnityEngine;

public class HellLauncher : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject hellPrompter;

    public string GetInteractText()
    {
        return "Launch hell";
    }

    public void Interact()
    {
        hellPrompter.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;;
    }

    public void Stay(){
        hellPrompter.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ProceedToLevelName(string name)
    {
        hellPrompter.SetActive(false);
        Time.timeScale = 1;
        StartCoroutine(FindObjectOfType<LevelManager>().LoadLevelByNameAfterTime(name));
    }
}
