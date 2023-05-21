using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour, IInteractable
{
    public bool isActive = false;

    public void Interact()
    {
        isActive = true;
    }

    public string GetInteractText()
    {
        return "Elevator activated";
    }
}
