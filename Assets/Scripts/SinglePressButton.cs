using System.Collections.Generic;
using UnityEngine;

public class SinglePressButton : MonoBehaviour, IInteractable
{
    [SerializeField] List<GameObject> linkedObjects;
    public bool hasBeenActivated = false;
    public bool canBeActivated = false;
    [SerializeField] Material inactiveMaterial;
    [SerializeField] Material activatedMaterial;
    public MeshRenderer meshRenderer;


    private void Awake() {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        // GetComponentInChildren<Renderer>().material = inactiveMaterial;
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

        // print(meshRenderer.materials[0]);
        // print(GetComponentInChildren<MeshRenderer>().materials[0]);
    }

    public string GetInteractText()
    {
        return "Press Button";
    }

    public void Interact()
    {
        
        if(/*hasBeenActivated ||*/ !canBeActivated){
            return;
        }

        hasBeenActivated = true;
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
