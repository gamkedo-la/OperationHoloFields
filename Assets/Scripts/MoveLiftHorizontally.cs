using UnityEngine;
using static LiftScript;

public class MoveLiftHorizontally : MonoBehaviour, IInteractable
{
    public LiftScript liftScript;


    private void Start()
    {

    }
    public string GetInteractText()
    {
        return "Move Lift Horizontally";
    }

    public void Interact()
    {
        MoveLift();
    }

    [ContextMenu("MoveLiftHorizontally")]
    public void MoveLift()
    {
        Debug.Log("inside MoveLift");
        if (liftScript.myState == LiftAnimState.Animating)
        {
            Debug.Log("the lift isn't activated");
            return;
        }
        else
        {
            if (liftScript.myState == LiftAnimState.Up)
            {
                liftScript.myAnimator.SetTrigger("AnimateMoveLiftHorizontally");
                liftScript.myState = LiftAnimState.Animating;
            }
            else if (liftScript.myState == LiftAnimState.MovingHorizontally)
            {
                liftScript.myAnimator.SetTrigger("AnimateLiftUp");
                liftScript.myState = LiftAnimState.Animating;
            }
        }
    }
}
