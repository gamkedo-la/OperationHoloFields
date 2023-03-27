using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBot : MonoBehaviour, IInteractable
{

    bool rotating = false;
    private float currentSpinAmount;

    public string GetInteractText()
    {
        return "Basic Bot";
    }

    public void Interact()
    {
        if(rotating){
            return;
        }
        rotating = true;
    }

    private void Update() {
        if(!rotating){
            return;
        }

        float spinSpeed = 360f * Time.deltaTime;
        currentSpinAmount += spinSpeed;
        transform.eulerAngles += new Vector3(0, spinSpeed, 0);
        
        if (currentSpinAmount > 360f)
            {
                currentSpinAmount = 0f;
                rotating = false;
                return;
            }

    }

    
}
