using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HoloLensDialogueScript : MonoBehaviour
{
    private GameObject dialogueRendererGameObject;
    private DialogueRenderer dialogueRendererScript;
    
    private bool alreadyTriggered = false;

    private void Start()
    {
        dialogueRendererGameObject = GameObject.FindGameObjectWithTag("DialogueRenderer");
        dialogueRendererScript = dialogueRendererGameObject.gameObject.transform.GetChild(0).GetComponent<DialogueRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !alreadyTriggered)
        {
            dialogueRendererScript.ShowDialogue("Press TAB to activate and deactivate HoloLens. \n\n Press Q to close.");
            
            alreadyTriggered = true;
        }
    }
}
