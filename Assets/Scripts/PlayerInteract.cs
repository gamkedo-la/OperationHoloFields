using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    GameObject interactibleObject = null;
    [SerializeField] float interactDistance = 2f;

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
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            Debug.Log(hit.transform);
            if(hit.transform.TryGetComponent<IInteractable>(out var interactable)){
                Debug.Log(interactable.GetInteractText());
                interactable.Interact();
            }

        }

        //if (interactibleObject == null) return;

        /* DoorOpener doorOpener = interactibleObject.GetComponent<DoorOpener>();
        if (doorOpener != null)
        {
            doorOpener.OpenDoor();
            UnsetInteractibleObject();
        } */
    }
}
