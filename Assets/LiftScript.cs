using UnityEngine;

public class LiftScript : MonoBehaviour, IInteractable
{
    public bool isActivated = false;
    public LiftAnimState myState = LiftAnimState.Down;
    public enum LiftAnimState
    {
        Down,
        Up,
        MovingHorizontally,
        Animating
    }

    public Animator myAnimator;

    private void Awake() 
    {
        myAnimator = transform.GetComponent<Animator>();
    }
    
    private void Start()
    {
        myAnimator.ResetTrigger("AnimateLiftUp");
        myAnimator.ResetTrigger("AnimateLiftDown");
        myAnimator.ResetTrigger("AnimateMoveLiftHorizontally");
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
        if (!isActivated || myState == LiftAnimState.Animating)
        {
            Debug.Log("the lift isn't activated");

            return;
        }
        else
        {
            if (myState == LiftAnimState.Down)
            {
                myAnimator.SetTrigger("AnimateLiftUp");
                myState = LiftAnimState.Animating;
            }
            else if (myState == LiftAnimState.Up)
            {
                myAnimator.SetTrigger("AnimateLiftDown");
                myState = LiftAnimState.Animating;
            }
        }
    }

    public void ChangeStateToIAmUp()
    {
        myState = LiftAnimState.Up;
    }

    public void ChangeStateToIAmDown()
    {
        myState = LiftAnimState.Down;
    }

    public void ChangeStateToIAmMovingHorizontally()
    {
        myState = LiftAnimState.MovingHorizontally;
    }
}
