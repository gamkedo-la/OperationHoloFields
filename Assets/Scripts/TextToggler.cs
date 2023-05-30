using UnityEngine;

public class TextToggler : MonoBehaviour
{
    [TextArea(15,20)]
    [SerializeField] private string textToDisplay;

    bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other) {
        if (hasBeenActivated) return;
        
        if(other.CompareTag("Player"))
        {
            other.transform.GetComponentInChildren<DialogueRenderer>().ShowDialogue(textToDisplay);
            hasBeenActivated = true;
        }
    }

    // private void OnTriggerExit(Collider other) {
    //     if(other.CompareTag("Player")){
    //         other.transform.GetComponentInChildren<DialogueRenderer>().HideDialogue();
    //     }
    // }
}
