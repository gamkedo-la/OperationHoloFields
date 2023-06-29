using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour, IInteractable
{
    [SerializeField] float fadeSpeed = 2f;
    [SerializeField] Fader fader;

    private void Awake() 
    {
        fader = FindObjectOfType<Fader>();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Interact()
    {
        StartCoroutine(LoadLevelAfterTime());
    }

    public string GetInteractText()
    {
        return "Managing levels";
    }

    private IEnumerator LoadLevelAfterTime()
    {
        fader.SetFadingSpeed(fadeSpeed);
        fader.ActivateFadeOut();
        yield return new WaitForSeconds(fadeSpeed + 1f);
        LoadNextLevel();
    }
}
