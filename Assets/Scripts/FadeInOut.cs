using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    
    public float fadeSpeed = 1;
    private bool fadeOut = false;
    private bool fadeIn = true;    
    void Start()
    {
        
    }

    void Update()
    {
        Material m = this.GetComponent<Renderer>().material;
        if (!m) return;
        
        if (fadeOut) {
            Color c = m.color;
            float amt = c.a - (fadeSpeed * Time.deltaTime);
            c = new Color(c.r,c.g,c.b,amt);
            m.color = c;
            if (c.a <= 0) {
                fadeOut = false;
                fadeIn = true;
            }
        }

        if (fadeIn) {
            Color c = m.color;
            float amt = c.a + (fadeSpeed * Time.deltaTime);
            c = new Color(c.r,c.g,c.b,amt);
            m.color = c;
            if (c.a >= 1) {
                fadeOut = true;
                fadeIn = false;
            }
        }
        
    }
}
