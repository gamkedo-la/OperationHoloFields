using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePressButton : MonoBehaviour, IInteractable
{

    [SerializeField] List<GameObject> linkedObjects;
    public bool hasBeenActivated = false;
    public bool canBeActivated = false;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activatedMaterial;


    private void Awake() {
        GetComponentInChildren<Renderer>().material = inactiveMaterial;
    }

    public string GetInteractText()
    {
        return "Press Button";
    }

    public void Interact()
    {
        
        if(hasBeenActivated || !canBeActivated){
            return;
        }

        hasBeenActivated = true;
        GetComponentInChildren<Renderer>().material = activatedMaterial;
        foreach (var item in linkedObjects)
        {
            if(item.TryGetComponent<IInteractable>(out var interactable)){
                interactable.Interact();
                return;
            }

            Debug.LogWarning("Linked Object in " + transform + " does not have an IInteractable component!");

        }
    }
}
