using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] float startFadeInSpeed = 3f; 
    private Fader fader;

    private void Awake() 
    {
        fader = FindObjectOfType<Fader>();
    }

    // Start is called before the first frame update
    void Start()
    {
        fader.FadeOutInstant();
        fader.SetFadingSpeed(startFadeInSpeed);
        fader.ActivateFadeIn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
