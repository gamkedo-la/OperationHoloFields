using System.Collections;
using System.Collections.Generic;
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
            liftScript.isActivated = true;
            singlePressButtonScript.canBeActivated = true;
        }
    }
}
