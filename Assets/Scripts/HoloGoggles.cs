using UnityEngine;
using UnityEngine.InputSystem;

public class HoloGoggles : MonoBehaviour
{
    private bool areActive = false;

    GameObject[] allHoloObjects;

    [SerializeField] GameObject scanlineRawImage;
    private Animator scanlineImageAnimatorComponent;

    private void Start() {
        allHoloObjects = GameObject.FindGameObjectsWithTag("Holo");
        SetHoloObjectsActive(false);
        scanlineImageAnimatorComponent = scanlineRawImage.GetComponent<Animator>();
    }

    public void OnToggle(InputAction.CallbackContext context)
    {
        Debug.Log("areActive: " + areActive);
        if (!areActive && context.performed)
        {
            SetHoloObjectsActive(true);
            scanlineImageAnimatorComponent.SetTrigger("OnToggleOn");
        }
        else if (areActive && context.performed)
        {
            //SetHoloObjectsActive(false);
            scanlineImageAnimatorComponent.SetTrigger("OnToggleOff");
        }
    }

    private void SetHoloObjectsActive(bool active)
    {
        foreach (GameObject holoObject in allHoloObjects)
        {
            holoObject.SetActive(active);
        }
        areActive = active;
    }

    public void SetHoloObjectsActiveFalse()
    {
        SetHoloObjectsActive(false);
    }
}
