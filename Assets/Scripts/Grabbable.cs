using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour, IInteractable
{

    PlayerGrab playerGrab;


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
        return "Grab";
    }

    public void Interact()
    {

        playerGrab.Grab(this);

    }


}
