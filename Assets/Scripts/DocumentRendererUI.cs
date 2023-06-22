using UnityEngine;

public class DocumentRendererUI : MonoBehaviour
{
    public void CloseDocument()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
