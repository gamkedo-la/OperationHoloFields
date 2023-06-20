using UnityEngine;
using TMPro;

public class DocumentRenderer : MonoBehaviour, IInteractable
{
    [SerializeField] DocumentsScriptableObject documentScriptableObject;
    [SerializeField] GameObject documentRendererUI;
    [SerializeField] TMP_Text documentRendererText;

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
        documentRendererUI.SetActive(true);
        documentRendererText.text = documentScriptableObject.GetContent();
    }
}