using UnityEngine;

public class DebugActivateAllButtons : MonoBehaviour
{
    private bool allButtonsActive = false;

    // Update is called once per frame
    void Update()
    {
        if (!allButtonsActive && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Activating All Buttons!");
            FindObjectOfType<PowerStation1Script>().ActivateButton();
            FindObjectOfType<PowerStationScript2>().ActivateButton();
            allButtonsActive = true;
        }
    }
}
