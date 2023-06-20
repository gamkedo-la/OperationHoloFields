using UnityEngine;

public class DocumentRenderer : MonoBehaviour, IInteractable
{
    [SerializeField] DocumentsScriptableObject documentScriptableObject;
    [SerializeField] GameObject documentRendererUI;

    private void Awake() 
    {
        // gameObject.tag = "Interactable";
    }

    public string GetInteractText()
    {
        return "Display document";
    }

    public void Interact()
    {
        Debug.Log(documentScriptableObject.GetContent());
    }
}