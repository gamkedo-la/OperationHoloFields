using UnityEngine;

public class GoggleOverlay : MonoBehaviour
{
    private RectTransform gogglesRectTransform;
    private bool currentState = false;
    private void Awake()
    {
        gogglesRectTransform = GetComponentInChildren<RectTransform>();
        HoloGoggles.OnHoloGogglesTriggered += ToggleHoloGoggles;
    }

    private void ToggleHoloGoggles(object sender, bool active)
    {
        if(active && !currentState)
        {

            currentState = true;
        }
        else if(!active && currentState)
        {
            gogglesRectTransform.localScale = new Vector3(0, 0, 0);
            currentState = false;
        }
    }
}
