using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using TMPro;

public class DialogueRenderer : MonoBehaviour
{
    [SerializeField] private Image dialogueBackground;
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private float sceneLoadTextDisplayDelay;
    private bool isDialogueEnabled = false;

    private void OnEnable()
    {
        Invoke("ShowSceneInitialDialogue", sceneLoadTextDisplayDelay);
    }

    public void ShowSceneInitialDialogue()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        string initialDialogue = "";

        switch (sceneName)
        {
            case "SampleScene":
                initialDialogue = "This is a sample scene here you can test the game \n\n Press Q to close";
                break;
            case "Warehouse":
                initialDialogue = "If an object highlights when you get close to it, press Enter to interact with it. \n\n Press Q to close.";
                break;
            // More dialogues can be added according to which scenes they belong to.
        }

        ShowDialogue(initialDialogue);
    }

    public void SetText(string newText)
    {
        textComponent.text = newText;
    }

    public void HideDialogue()
    {
        dialogueBackground.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
        isDialogueEnabled = false;
    }

    public void ShowDialogue(string dialogueToShow)
    {
        if (dialogueToShow != null)
        {
            SetText(dialogueToShow);
        }
        dialogueBackground.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
        isDialogueEnabled = true;
    }

    private void Update() {
        if(isDialogueEnabled && Keyboard.current.qKey.wasPressedThisFrame) {
            HideDialogue();
            SetText("");
        }
    }
}
