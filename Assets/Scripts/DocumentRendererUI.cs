using UnityEngine;
using TMPro;

public class DocumentRendererUI : MonoBehaviour
{
    [SerializeField] TMP_Text documentRendererText;
    [SerializeField] TMP_Text documentTitle;
    [SerializeField] TMP_Text documentAuthorText;
    [SerializeField] TMP_Text documentReceiverText;
    [SerializeField] TMP_Text documentTypeText;

    public void SetAllTexts(DocumentsScriptableObject documentScriptableObject)
    {
        documentRendererText.text = documentScriptableObject.GetContent();
        documentTitle.text = documentScriptableObject.GetTitle();
        documentAuthorText.text = "FROM: " + documentScriptableObject.GetAuthor();
        documentReceiverText.text = "TO: " + documentScriptableObject.GetReceiver();
        SetDocumentTypeText(documentScriptableObject.GetDocumentType());
    }

    public void CloseDocument()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void SetDocumentTypeText(DocumentsScriptableObject.DocumentType documentType)
    {
        string documentTypeString;

        switch (documentType)
        {
            case DocumentsScriptableObject.DocumentType.email:
                documentTypeString = "Email Exchange";
                break;

            case DocumentsScriptableObject.DocumentType.internalChat:
                documentTypeString = "Internal Messaging Archive";
                break;

            case DocumentsScriptableObject.DocumentType.memo:
                documentTypeString = "Company Memo";
                break;

            case DocumentsScriptableObject.DocumentType.writtenNoteTranscript:
                documentTypeString = "Written Note Transcript";
                break;

            case DocumentsScriptableObject.DocumentType.labReport:
                documentTypeString = "Laboratories Reports";
                break;
            
            default:
                documentTypeString = "Unknown document";
                break;
        }

        documentTypeText.text = documentTypeString;
    }
}
