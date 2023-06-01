using UnityEngine;

public class PowerStation1Script : MonoBehaviour
{
    [SerializeField] GameObject lift;
    private LiftScript liftScript;

    [SerializeField] GameObject myButton;
    private SinglePressButton singlePressButtonScript;

    private void Start()
    {
        liftScript = lift.transform.GetComponent<LiftScript>();
        singlePressButtonScript = myButton.GetComponent<SinglePressButton>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EnergyCrate")
        {
            ActivateButton();
        }
    }

    public void ActivateButton()
    {
        print("Youpie");
        liftScript.isActivated = true;
        singlePressButtonScript.canBeActivated = true;
    }
}
