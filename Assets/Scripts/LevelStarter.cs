using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] float startFadeInSpeed = 3f; 
    [SerializeField] bool cutSceneWithNoPlayer = false;
    private Fader fader;

    private void Awake()
    {
        fader = FindObjectOfType<Fader>();
        DisablePlayerInput();
    }

    // Start is called before the first frame update
    IEnumerator Start()
    {
        HideCursor();
        InitiateFadeIn();

        yield return new WaitForSeconds(startFadeInSpeed * 0.25f);
        InablePlayerInput();
    }

    private void DisablePlayerInput()
    {
        if (cutSceneWithNoPlayer) return;

        InputActionAsset actions = FindObjectOfType<PlayerInput>().actions;
        actions.FindActionMap("Player").Disable();
        actions.FindActionMap("DeadPlayer").Enable();
    }

    private void InablePlayerInput()
    {
        if (cutSceneWithNoPlayer) return;

        InputActionAsset actions = FindObjectOfType<PlayerInput>().actions;
        actions.FindActionMap("Player").Enable();
        actions.FindActionMap("DeadPlayer").Disable();
    }

    private void InitiateFadeIn()
    {
        fader.FadeOutInstant();
        fader.SetFadingSpeed(startFadeInSpeed);
        fader.ActivateFadeIn();
    }

    private void HideCursor()
    {
        if (cutSceneWithNoPlayer) return;
     
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
