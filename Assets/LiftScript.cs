using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftScript : MonoBehaviour, IInteractable
{
    public bool isActivated = false;
    public string myState = "I am down";
    private Animator myAnimator;
    

    private void Start()
    {
        myAnimator = transform.GetComponent<Animator>();
        
    }
    public string GetInteractText()
    {
        return "Lifting the lift";
    }

    public void Interact()
    {
        LiftTheLift();
    }

    [ContextMenu("LiftTheLift")]
    public void LiftTheLift()
    {
        Debug.Log("inside LiftTheLift");
        if (!isActivated || myState == "I am animating")
        {
            Debug.Log("the lift isn't activated");

            return;
        }
        else
        {
            if (myState == "I am down")
            {
                myAnimator.SetTrigger("AnimateLiftUp");
                myState = "I am animating";
            }
            else if (myState == "I am up")
            {
                myAnimator.SetTrigger("AnimateLiftDown");
                myState = "I am animating";
            }
        }
    }

    public void ChangeStateToIAmUp()
    {
        myState = "I am up";
    }

    public void ChangeStateToIAmDown()
    {
        myState = "I am down";
    }
}