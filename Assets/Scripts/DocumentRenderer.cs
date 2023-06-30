using UnityEngine;

public class DocumentRenderer : MonoBehaviour, IInteractable
{
    [SerializeField] DocumentsScriptableObject documentScriptableObject;
    [SerializeField] DocumentRendererUI documentRendererUI;

    public string GetInteractText()
    {
        return "Display document";
    }

    public void Interact()
    {
        documentRendererUI.SetAllTexts(documentScriptableObject);
        documentRendererUI.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            if (documentRendererUI.gameObject.activeSelf == true)
            {
                documentRendererUI.gameObject.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
} 