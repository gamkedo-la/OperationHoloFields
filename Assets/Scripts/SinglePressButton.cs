using System.Collections.Generic;
using UnityEngine;

public class SinglePressButton : MonoBehaviour, IInteractable
{
    [SerializeField] List<GameObject> linkedObjects;
    public bool hasBeenActivated = false;
    public bool canBeActivated = false;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activatedMaterial;
    [SerializeField] bool canBePressedOnlyOnce = true;
    private bool hasBeenPressedOnce = false;
    private MeshRenderer meshRenderer;


    private void Awake() 
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        SetButtonCenterMaterial(inactiveMaterial);
    }

    private void SetButtonCenterMaterial(Material material)
    {
        Material[] materials = meshRenderer.materials;
        materials[0].CopyPropertiesFromMaterial(material);
        meshRenderer.materials = materials;

        InteractableObjectScript interactableObject = GetComponent<InteractableObjectScript>();
        if (interactableObject != null)
        {
            interactableObject.originalMaterial = material;
        }
    }

    public string GetInteractText()
    {
        return "Press Button";
    }

    public void Interact()
    {
        if(canBePressedOnlyOnce && hasBeenPressedOnce) return;
        if(!canBeActivated) return;

        if (!hasBeenPressedOnce) hasBeenPressedOnce = true;

        SetButtonCenterMaterial(activatedMaterial);
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
