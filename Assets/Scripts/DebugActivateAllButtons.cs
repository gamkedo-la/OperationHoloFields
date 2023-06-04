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
            foreach(SinglePressButton button in FindObjectsOfType<SinglePressButton>())
            {
                if (!button.canBeActivated)
                {
                    button.Activate();
                }
            }
            allButtonsActive = true;
        }
    }
}
