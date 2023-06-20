using UnityEngine;

[CreateAssetMenu(fileName = "DocumentsScriptableObject", menuName = "OperationHoloFields/DocumentsScriptableObject", order = 0)]
public class DocumentsScriptableObject : ScriptableObject 
{
    [TextArea(10, 100)]
    [SerializeField] string content;
    [SerializeField] string author;

    public string  GetContent()
    {
        return content;
    }
}
