using UnityEngine;
using TMPro;

public class DocumentRenderer : MonoBehaviour, IInteractable
{
    [SerializeField] DocumentsScriptableObject documentScriptableObject;
    [SerializeField] GameObject documentRendererUI;
    [SerializeField] TMP_Text documentRendererText;

    public string GetInteractText()
    {
        return "Display document";
    }

    public void Interact()
    {
        documentRendererUI.SetActive(true);
        documentRendererText.text = documentScriptableObject.GetContent();
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}