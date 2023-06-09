using UnityEngine;

public class PowerStation : MonoBehaviour
{
    [SerializeField] GameObject myButton;
    private SinglePressButton singlePressButtonScript;
    private bool hasBeenActivated = false;

    private void Start()
    {
        singlePressButtonScript = myButton.GetComponent<SinglePressButton>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenActivated) return;

        if (other.gameObject.name == "EnergyCrate")
        {
            if (other.gameObject.GetComponent<Grabbable>().GetIsGrabbed())
            {
                FindObjectOfType<PlayerGrab>().Drop();
            }
            singlePressButtonScript.Activate();
            other.gameObject.tag = "Untagged";
            other.gameObject.GetComponent<Grabbable>().SetGrabEnabled(false);
            hasBeenActivated = true;
        }
    }
}
