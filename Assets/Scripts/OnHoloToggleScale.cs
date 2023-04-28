using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoloToggleScale : MonoBehaviour
{
    
    [SerializeField] float holoScaleAmount = 1.1f;

    float desiredScale = 1f;
    bool scaling;
    float scaleTime = 0f;

    private void Start() {
        HoloGoggles.OnHoloGogglesTriggered += HoloGoggles_OnHoloGogglesTriggered;
    }

    private void HoloGoggles_OnHoloGogglesTriggered(object sender, bool e)
    {
        OnHoloToggle(e);
    }

    public void OnHoloToggle(bool holoState)
    {
        Debug.Log("HoloToggle: " + holoState);
        scaling = true;
        if(holoState){
            desiredScale = holoScaleAmount;
            return;
        }
        desiredScale = 1f;
    }

    private void Update() {
        if(!scaling){
            scaleTime = 0f;
            return;
        }
        scaleTime+= Time.deltaTime;

        float newScale = Mathf.Lerp(transform.localScale.y, desiredScale, scaleTime);

        transform.localScale = new Vector3(newScale,newScale,newScale);

        if(Mathf.Abs(newScale - desiredScale) < 0.01f){
            scaling = false;
            scaleTime = 0f;
        }

    }
}
