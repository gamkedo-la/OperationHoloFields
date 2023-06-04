using UnityEngine;

public class PowerStation : MonoBehaviour
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
            singlePressButtonScript.Activate();
        }
    }
}
