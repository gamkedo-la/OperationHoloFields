using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCameraBehaviors : MonoBehaviour
{
    private void Awake()
    {
        HoloGoggles.OnHoloGogglesTriggered += ToggleHoloGoggles;
    }
    private void ToggleHoloGoggles(object sender, bool areActive)
    {
        // Add or remove holo-goggles camera effects
    }
}
