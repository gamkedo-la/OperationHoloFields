using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScanlineScript : MonoBehaviour
{
    private HoloGoggles holoGogglesScript;
    // Start is called before the first frame update
    void Start()
    {
        holoGogglesScript = GameObject.Find("Player").GetComponent<HoloGoggles>();
    }

    public void SetHoloObjectsActiveFalse()
    {
        holoGogglesScript.SetHoloObjectsActiveFalse();
    }
}
