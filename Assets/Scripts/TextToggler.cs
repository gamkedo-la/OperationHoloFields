using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToggler : MonoBehaviour
{
    [TextArea(15,20)]
    [SerializeField] private string textToDisplay;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            other.transform.GetComponentInChildren<DialogueRenderer>().ShowDialogue(textToDisplay);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            other.transform.GetComponentInChildren<DialogueRenderer>().HideDialogue();
        }
    }
}
