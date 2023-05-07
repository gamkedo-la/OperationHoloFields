using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaDoorPress : MonoBehaviour, IInteractable
{

    [SerializeField] List<GameObject> linkedObjects;
    bool hasBeenActivated = false;

    public static event EventHandler<bool> RoombaDoorTriggered;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activatedMaterial;


    private void Awake()
    {
        GetComponentInChildren<Renderer>().material = inactiveMaterial;
    }

    public string GetInteractText()
    {
        return "Press Button";
    }

    public void Interact()
    {
        if (hasBeenActivated)
        {
            return;
        }

        hasBeenActivated = true;
        RoombaDoorTriggered?.Invoke(this, hasBeenActivated);
        GetComponentInChildren<Renderer>().material = activatedMaterial;
        foreach (var item in linkedObjects)
        {
            if (item.TryGetComponent<IInteractable>(out var interactable))
            {
                interactable.Interact();
                return;
            }

            Debug.LogWarning("Linked Object in " + transform + " does not have an IInteractable component!");

        }
    }
}
