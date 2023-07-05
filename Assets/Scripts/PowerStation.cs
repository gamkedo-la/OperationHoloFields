using UnityEngine;

public class PowerStation : MonoBehaviour
{
    [SerializeField] SinglePressButton[] myButtons;
    private bool hasBeenActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenActivated) return;

        if (other.gameObject.name == "EnergyCrate")
        {
            if (other.gameObject.GetComponent<Grabbable>().GetIsGrabbed())
            {
                FindObjectOfType<PlayerGrab>().Drop();
            }

            foreach(SinglePressButton myButton in myButtons)
            {
                myButton.Activate();
                other.gameObject.tag = "Untagged";
                other.gameObject.GetComponent<Grabbable>().SetGrabEnabled(false);
            }
            
            hasBeenActivated = true;
        }
    }
}
