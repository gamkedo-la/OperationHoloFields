using UnityEngine;
using UnityEngine.Playables;


public class DoorOpener : MonoBehaviour
{
    [SerializeField] PlayableDirector playableDirector;
    private bool hasBeenActivated = false;

    public void OpenDoor()
    {
        playableDirector.Play();
        hasBeenActivated = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (!other.CompareTag("Player")) return;
        if (hasBeenActivated) return;

        PlayerInteract playerInteract = other.GetComponent<PlayerInteract>();
        playerInteract.SetInteractibleObject(gameObject);
    }

    private void OnTriggerExit(Collider other) 
    {
        
        if (!other.CompareTag("Player")) return;
        if (hasBeenActivated) return;

        PlayerInteract playerInteract = other.GetComponent<PlayerInteract>();
        playerInteract.UnsetInteractibleObject();
    }
}
