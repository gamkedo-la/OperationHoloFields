using System.Collections.Generic;
using UnityEngine;

public class SinglePressButton : MonoBehaviour, IInteractable
{
    [SerializeField] List<GameObject> linkedObjects;
    public bool canBeActivated = false;
    [SerializeField] Material unpressedMaterial;
    [SerializeField] Material pressedMaterial;
    
    [SerializeField] Material activeMaterial;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] bool canBePressedOnlyOnce = true;
    private bool hasBeenPressedOnce = false;
    private MeshRenderer meshRenderer;
    private int buttonCenterMaterialIdx = 0;
    private int buttonSurroundingMaterialIdx = 2;


    private void Awake() 
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        SetButtonCenterMaterial(unpressedMaterial);

        if (canBeActivated)
        {
            SetButtonSurroundingMaterial(activeMaterial);
        }
        else
        {
            SetButtonSurroundingMaterial(inactiveMaterial);
        }
    }

    private void SetButtonMaterialAtIdx(int matIdx, Material material)
    {
        Material[] materials = meshRenderer.materials;
        materials[matIdx].CopyPropertiesFromMaterial(material);
        meshRenderer.materials = materials;
    }

    private void SetButtonCenterMaterial(Material material)
    {
        SetButtonMaterialAtIdx(buttonCenterMaterialIdx, material);
        InteractableObjectScript interactableObject = GetComponent<InteractableObjectScript>();
        if (interactableObject != null)
        {
            interactableObject.originalMaterial = material;
        }
    }
    
    private void SetButtonSurroundingMaterial(Material material)
    {
        SetButtonMaterialAtIdx(buttonSurroundingMaterialIdx, material);
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
        if (canBePressedOnlyOnce) SetButtonCenterMaterial(pressedMaterial);

        foreach (var item in linkedObjects)
        {
            if(item.TryGetComponent<IInteractable>(out var interactable)){
                interactable.Interact();
                return;
            }

            Debug.LogWarning("Linked Object in " + transform + " does not have an IInteractable component!");
        }
    }

    public void Activate()
    {
        canBeActivated = true;
        SetButtonSurroundingMaterial(activeMaterial);
    }
}
