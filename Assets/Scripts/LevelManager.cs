using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour, IInteractable
{
    [SerializeField] float fadeSpeed = 2f;
    [SerializeField] Image fadeImage;

    private bool isFading = false;

    private void Update() 
    {
        FadeOut();
    }

    private void FadeOut()
    {
        if(!isFading) return;

        Color tempColor = fadeImage.color;
        tempColor.a += 1f / fadeSpeed * Time.deltaTime;
        fadeImage.color = tempColor;
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
        isFading = true;
        yield return new WaitForSeconds(fadeSpeed + 1f);
        LoadNextLevel();
    }
}
