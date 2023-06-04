using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSinglePressButton : MonoBehaviour, IInteractable
{

    [SerializeField] List<GameObject> linkedObjects;
    public bool hasBeenActivated = false;
    public bool canBeActivated = false;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activatedMaterial;


    private void Awake()
    {
        GetComponentInChildren<Renderer>().material = inactiveMaterial;
    }

    public string GetInteractText()
    {
        return "Elevator Activated";
    }

    public void Interact()
    {

        canBeActivated = true;

        //hasBeenActivated = true;
        //GetComponentInChildren<Renderer>().material = activatedMaterial;
        //foreach (var item in linkedObjects)
        //{
        //    Debug.Log("inside foreach");
        //    if (item.TryGetComponent<IInteractable>(out var interactable))
        //    {
        //        Debug.Log("found interactable");
        //        interactable.Interact();
        //        return;
        //    }

        //    Debug.LogWarning("Linked Object in " + transform + " does not have an IInteractable component!");

        //}
    }
}
