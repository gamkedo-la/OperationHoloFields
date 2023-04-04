using UnityEngine;
using UnityEngine.Playables;


public class DoorOpener : MonoBehaviour, IInteractable
{
    [SerializeField] PlayableDirector playableDirector;
    private bool hasBeenActivated = false;

    public string GetInteractText()
    {
        return "Open Door";
    }

    public void Interact()
    {
        OpenDoor();
    }

    public void OpenDoor()
    {
        Debug.Log("Hey Ho");
        playableDirector.Play();
        hasBeenActivated = true;
    }

    // private void OnTriggerEnter(Collider other) 
    // {
    //     if (!other.CompareTag("Player")) return;
    //     if (hasBeenActivated) return;

    //     PlayerInteract playerInteract = other.GetComponent<PlayerInteract>();
    //     playerInteract.SetInteractibleObject(gameObject);
    // }

    // private void OnTriggerExit(Collider other) 
    // {
        
    //     if (!other.CompareTag("Player")) return;
    //     if (hasBeenActivated) return;

    //     PlayerInteract playerInteract = other.GetComponent<PlayerInteract>();
    //     playerInteract.UnsetInteractibleObject();
    // }
}
