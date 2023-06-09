using UnityEngine;

public class Grabbable : MonoBehaviour, IInteractable
{

    PlayerGrab playerGrab;
    private bool isGrabbed = false;
    private bool grabEnabled = true;

    private void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerGrab = player.GetComponent<PlayerGrab>();
        }
    }

    public string GetInteractText()
    {
        if (!grabEnabled) return "";
        return "Grab";
    }

    public void Interact()
    {
        if (!grabEnabled) return;
        playerGrab.Grab(this);
    }

    public void SetIsGrabbed(bool value)
    {
        isGrabbed = value;
    }

    public bool GetIsGrabbed()
    {
        return isGrabbed;
    }

    public void SetGrabEnabled(bool value)
    {
        grabEnabled = value;
    }

}
