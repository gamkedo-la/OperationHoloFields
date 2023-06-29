using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fader : MonoBehaviour 
{
    private Image image;
    private bool isFadingIn = false;
    private bool isFadingOut = false;
    private float fadeSpeed = 2f;

    private void Awake() 
    {
        image = GetComponent<Image>();
    }

    private void Update() 
    {
        FadeIn();
        FadeOut();
    }

    private void FadeIn()
    {
        if(!isFadingIn) return;

        Color tempColor = image.color;

        float newAlpha = tempColor.a - 1f / fadeSpeed * Time.deltaTime;
        if (newAlpha <= 0)
        {
            isFadingIn = false;
        }
        
        tempColor.a = newAlpha;
        image.color = tempColor;
    }
    
    private void FadeOut()
    {
        if(!isFadingOut) return;

        Color tempColor = image.color;

        float newAlpha = tempColor.a + 1f / fadeSpeed * Time.deltaTime;
        if (newAlpha >= 1)
        {
            isFadingOut = false;
        }
        
        tempColor.a = newAlpha;
        image.color = tempColor;
    }

    public void ActivateFadeOut()
    {
        isFadingOut = true;
    }

    public void ActivateFadeIn()
    {
        isFadingIn = true;
    }

    public void ActivateFadeOutFadeInAtSpeed(float speed)
    {
        fadeSpeed = speed / 2;
        StartCoroutine(FadeOutFadeIn());
    }

    private IEnumerator FadeOutFadeIn()
    {
        isFadingIn = false;
        isFadingOut = true;
        yield return new WaitForSeconds(fadeSpeed);
        isFadingOut = false;
        isFadingIn = true;
    }

    public void SetFadingSpeed(float newSpeed)
    {
        fadeSpeed = newSpeed;
    }
}