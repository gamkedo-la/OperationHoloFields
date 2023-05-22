using System.Collections;
using System.Collections.Generic;
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
            singlePressButtonScript.canBeActivated = true;
            Debug.Log("horizontal movement of lift button activated");
        }
    }
}
