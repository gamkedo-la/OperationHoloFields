using UnityEngine;

[CreateAssetMenu(fileName = "DocumentsScriptableObject", menuName = "OperationHoloFields/DocumentsScriptableObject", order = 0)]
public class DocumentsScriptableObject : ScriptableObject 
{
    public enum DocumentType {email, internalChat, memo, writtenNoteTranscript, labReport};

    [TextArea(10, 100)]
    [SerializeField] string content;
    [SerializeField] string title;
    [SerializeField] string author;
    [SerializeField] string receiver;
    [SerializeField] DocumentType documentType;

    public string  GetContent()
    {
        return content;
    }

    public string GetTitle()
    {
        return title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public string GetReceiver()
    {
        return receiver;
    }

    public DocumentType GetDocumentType()
    {
        return documentType;
    }
}
