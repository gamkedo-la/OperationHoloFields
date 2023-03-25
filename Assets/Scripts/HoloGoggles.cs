using UnityEngine;
using UnityEngine.InputSystem;

public class HoloGoggles : MonoBehaviour
{
    private bool areActive = false;

    GameObject[] allHoloObjects;

    private void Start() {
        allHoloObjects = GameObject.FindGameObjectsWithTag("Holo");
        SetHoloObjectsActive(false);
    }

    public void OnToggle(InputAction.CallbackContext context)
    {
        if (!areActive)
        {
            SetHoloObjectsActive(true);
        }
        else
        {
            SetHoloObjectsActive(false);
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
}
