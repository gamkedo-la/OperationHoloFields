using UnityEngine;

public class PowerStationScript2 : MonoBehaviour
{
    [SerializeField] GameObject myButton;
    private SinglePressButton singlePressButtonScript;

    private void Start()
    {
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
        singlePressButtonScript.canBeActivated = true;
        Debug.Log("horizontal movement of lift button activated");
    }
}
