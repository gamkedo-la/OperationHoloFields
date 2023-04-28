using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class HoloGoggles : MonoBehaviour
{

    public static event EventHandler<bool> OnHoloGogglesTriggered;

    private bool areActive = false;

    GameObject[] allHoloObjects;

    [SerializeField] GameObject scanlineRawImage;
    private Animator scanlineImageAnimatorComponent;

    private AudioSource scanlineAudioEffectsPlayer;
    [SerializeField] AudioClip scanlineOnSoundEffect;

    private void Start() {
        allHoloObjects = GameObject.FindGameObjectsWithTag("Holo");
        SetHoloObjectsActive(false);
        //scanlineImageAnimatorComponent = scanlineRawImage.GetComponent<Animator>();
        //scanlineAudioEffectsPlayer = GetComponent<AudioSource>();
    }

    public void OnToggle(InputAction.CallbackContext context)
    {
        Debug.Log("areActive: " + areActive);
        
        if (!areActive && context.performed)
        {
            SetHoloObjectsActive(true);
            //scanlineAudioEffectsPlayer.clip = scanlineOnSoundEffect;
            //scanlineAudioEffectsPlayer.Play();
            //scanlineImageAnimatorComponent.SetTrigger("OnToggleOn");
        }
        else if (areActive && context.performed)
        {
            SetHoloObjectsActive(false);
            //scanlineImageAnimatorComponent.SetTrigger("OnToggleOff");
        }
        
    }

    private void SetHoloObjectsActive(bool active)
    {
        foreach (GameObject holoObject in allHoloObjects)
        {
            holoObject.SetActive(active);
        }
        areActive = active;
        OnHoloGogglesTriggered?.Invoke(this, areActive);
    }

    public void SetHoloObjectsActiveFalse()
    {
        SetHoloObjectsActive(false);
    }
}
