using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    GameObject interactibleObject = null;

    public void SetInteractibleObject(GameObject toSet)
    {
        interactibleObject = toSet;
    }

    public void UnsetInteractibleObject()
    {
        interactibleObject = null;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (interactibleObject == null) return;

        DoorOpener doorOpener = interactibleObject.GetComponent<DoorOpener>();
        if (doorOpener != null)
        {
            doorOpener.OpenDoor();
            UnsetInteractibleObject();
        }
    }
}
