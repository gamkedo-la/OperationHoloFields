using UnityEngine;
using UnityEngine.Playables;


public class DoorOpener : MonoBehaviour, IInteractable
{
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] AudioSource openSound;

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
        playableDirector.Play();
        openSound.pitch = Random.Range(0.75f, 1.25f);
        openSound.Play();
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